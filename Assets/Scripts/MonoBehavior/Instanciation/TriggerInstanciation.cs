using UnityEngine;

public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject SpawnTrigger;
    [SerializeField] GameObject NextChunk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnTrigger"))
        {
            Instantiate(NextChunk, new Vector3(0, -0.5f, 382.75f), Quaternion.identity);
        }
    }
}
