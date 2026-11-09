using UnityEngine;

public class Destroy_Potions : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision) // A la collision on détruit la potion passé par le joueur.
    {
        if (CompareTag("Potion") == true)    
        {
            Destroy(collision.gameObject);
        }
    }
}
