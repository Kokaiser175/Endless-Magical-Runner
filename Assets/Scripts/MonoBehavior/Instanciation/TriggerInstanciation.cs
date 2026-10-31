using JetBrains.Annotations;
using System.Collections;
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

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject m_HealthPotion;
    [SerializeField] GameObject m_ManaPotion;

    private int value;
    private List<Vector3> m_AnchorPositions = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { return; }

        value = Random.Range(0, 100);

        if (other.gameObject.CompareTag("SpawnTrigger"))
        {
            Vector3 spawn = spawnPoint.transform.position;
            GameObject newChunk = null;


            if (value < 10)
            {
                newChunk = Instantiate(Chunk1, spawn, Quaternion.identity);
            }
            if (value >= 10 && value <= 19)
            {
                newChunk = Instantiate(Chunk2, spawn, Quaternion.identity);
            }
            if (value >= 20 && value <= 39)
            {
                newChunk = Instantiate(Chunk3, spawn, Quaternion.identity);
            }
            if (value >= 40 && value <= 69)
            {
                newChunk = Instantiate(Chunk4, spawn, Quaternion.identity);
            }
            if (value >= 70 && value <= 89)
            {
                newChunk = Instantiate(Chunk5, spawn, Quaternion.identity);
            }
            if (value >= 90 && value <= 100)
            {
                newChunk = Instantiate(Chunk6, spawn, Quaternion.identity);
            }

            GetAnchorPositions(newChunk);
            SpawnPotions();
        }
    }
    private void GetAnchorPositions(GameObject chunk)
    {
        m_AnchorPositions.Clear();

        foreach (Transform anchor in chunk.GetComponentsInChildren<Transform>())
        {
            if (anchor.CompareTag("AnchorPosition"))
            {
                m_AnchorPositions.Add(anchor.position);
            }
        }
        Debug.Log("Nombre d'ancres : " + m_AnchorPositions.Count);
    }

    private void SpawnPotions()
    {
        int randomIndex = Random.Range(0, m_AnchorPositions.Count);
        Vector3 position = m_AnchorPositions[randomIndex];

            if (Random.Range(0, 100) < 50)
            {
                GameObject potion = Random.Range(0, 2) == 0
                    ? m_HealthPotion
                    : m_ManaPotion;

                Instantiate(potion, position, Quaternion.identity);
            }
        
    }
}
