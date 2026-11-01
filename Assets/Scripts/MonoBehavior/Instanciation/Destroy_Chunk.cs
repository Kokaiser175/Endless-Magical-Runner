using UnityEngine;

public class Destroy_Chunk : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
            Destroy(collision.gameObject); // A la collision on détruit le Chunk passé par le joueur. 
    }
}
