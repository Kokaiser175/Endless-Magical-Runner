using System.Collections.Generic;
using UnityEngine;


public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject Chunk1;
    [SerializeField] GameObject Chunk2;
    [SerializeField] GameObject Chunk3;
    [SerializeField] GameObject Chunk4;
    [SerializeField] GameObject Chunk5;
    [SerializeField] GameObject Chunk6;
    [SerializeField] GameObject Chunk7;
    [SerializeField] GameObject Chunk8;
    [SerializeField] GameObject Chunk9;
    [SerializeField] GameObject Chunk10;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject m_HealthPotion;
    [SerializeField] GameObject m_ManaPotion;

    private int value;
    private List<Vector3> m_AnchorPositions = new List<Vector3>(); //Liste des différentes ancres.


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) { return; } // Pour éviter une double activation on renvoi si le tag est celui du joueur. 

        value = Random.Range(0, 100); // value prend la valeur du Random Range.
        Debug.Log(value);

        if (other.gameObject.CompareTag("SpawnTrigger")) // Si le joueur touche la hit box avec le tag SpawnTrigger.
        {
            Vector3 spawn = spawnPoint.transform.position; // On récupère la position du spawn point dans une variable locale. 
            GameObject newChunk = null; // On crée une variable Gameobject qui deviendra le Chunk instancié. 

            if (value < 10)
            {
                newChunk = Instantiate(Chunk1, spawn, Quaternion.identity);
            }
            if (value >= 10 && value <= 19)
            {
                newChunk = Instantiate(Chunk2, spawn, Quaternion.identity);
            }
            if (value >= 20 && value <= 29)
            {
                newChunk = Instantiate(Chunk3, spawn, Quaternion.identity);
            }
            if (value >= 30 && value <= 39)
            {
                newChunk = Instantiate(Chunk4, spawn, Quaternion.identity);
            }
            if (value >= 40 && value <= 49)
            {
                newChunk = Instantiate(Chunk5, spawn, Quaternion.identity);
            }
            if (value >= 50 && value <= 59)
            {
                newChunk = Instantiate(Chunk6, spawn, Quaternion.identity);
            }
            if (value >= 60 && value <= 69)
            {
                newChunk = Instantiate(Chunk7, spawn, Quaternion.identity);
            }
            if (value >= 70 && value <= 79)
            {
                newChunk = Instantiate(Chunk8, spawn, Quaternion.identity);
            }
            if (value >= 80 && value <= 89)
            {
                newChunk = Instantiate(Chunk9, spawn, Quaternion.identity);
            }
            if (value >= 90 && value <= 100)
            {
                newChunk = Instantiate(Chunk10, spawn, Quaternion.identity);
            }


            GetAnchorPositions(newChunk);
            SpawnPotions();
        }
    }
    private void GetAnchorPositions(GameObject chunk) // On ajoute les position des ancres dans la liste au moment de l'instanciation
    {
        m_AnchorPositions.Clear(); // On vide la liste pour ne garder que la position du chunk instancié

        foreach (Transform anchor in chunk.GetComponentsInChildren<Transform>()) // On parcours tout les composants "ancres" du Chunk instancié pour en récupérer le Transform. 
        {
            if (anchor.CompareTag("AnchorPosition")) // On vérifie avec un tag de ne récupérer que les Transform des ancres. 
            {
                m_AnchorPositions.Add(anchor.position); // On ajoute les positions à la liste. 
            }
        }
        Debug.Log("Nombre d'ancres : " + m_AnchorPositions.Count);
    }

    private void SpawnPotions() // On place aléatoirement 1 seule position à la position des ancres dans la liste. 
    {
        int randomIndex = Random.Range(0, m_AnchorPositions.Count); // On choisit une ancre avec un random range.
        Vector3 position = m_AnchorPositions[randomIndex]; // La position devient celle de l'ancre choisit. 

            if (Random.Range(0, 100) < 50) // Si le random Range est inférieur à 50 une potion apparaît. 
            {
                GameObject potion = Random.Range(0, 2) == 0 // opérateur ternaire pour choisir quelle potion instancier. (2, est ici, toujours exclu)
                    ? m_HealthPotion // Si le résultat vaut 0 c'est HealthPotion
                    : m_ManaPotion; // Si le resultat vaut 1 c'est ManaPotion

                Instantiate(potion, position, Quaternion.identity);
            }
        
    }
}
