using UnityEngine;

public class Destroy_Chunk : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
            Destroy(collision.gameObject);
    }
}
