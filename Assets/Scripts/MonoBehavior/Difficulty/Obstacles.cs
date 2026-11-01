using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] RSO_ObstacleValues hit;
    [SerializeField] RSO_Health player_Health;
    [SerializeField] GameObject m_Player;
    public float invulnerabilityFrame;
    public bool hasBeenHit;

    private void Start()
    {
        hit.hitValue = 1; // Valeur de dégat de base d'un obstacle. 
        hasBeenHit = false; // booléen qui gère si le joueur est touché ou non. 
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle")) // A la collision on compare le tag pour savoir si on touche bien un obstacle. 
        {
               if (hasBeenHit == false) // Si le booléen est faux on lance la coroutine. 
                {
                StartCoroutine(InvincibilityFrame()); 
                }
            else { return; } // Si le booléen est vrai on renvoi la fonction, le joueur ne peut pas prendre de dégât. 
        }
        
    }
    private IEnumerator InvincibilityFrame()
    {
        GetHit(); // On appelle la fonction qui gère les dégats.
        hasBeenHit = true; // Ensuite on passe le booléen à vrai. 
        yield return new WaitForSeconds(invulnerabilityFrame); // On attend que l'invulnérabilité du joueur se termine.
        hasBeenHit = false; // On repasse le booléen à faux pour pouvoir reprendre un dégât.
    }
    private void GetHit()
    {
        player_Health.Value = player_Health.Value - hit.hitValue; // On réduit la vie du joueur de la valeur de dégât de l'obstacle. 
    }

}
