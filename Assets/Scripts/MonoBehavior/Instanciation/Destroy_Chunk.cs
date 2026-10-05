using UnityEngine;

public class Destroy_Chunk : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
 
            Debug.Log("Destroy Check");
            Destroy(collision.gameObject);
        
    }
}
