using System.Collections;
using UnityEngine;

public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject Chunk1;
    [SerializeField] GameObject Chunk2;
    [SerializeField] GameObject Chunk3;
    [SerializeField] GameObject spawnPoint;
    private int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { return; }

        value = Random.Range(0, 100);
        Debug.Log($"{value.ToString()}");


        if (other.gameObject.CompareTag("SpawnTrigger"))
        {
            Vector3 spawn = spawnPoint.transform.position;
            
            if (value <= 33)
            {
                Instantiate(Chunk1, spawn, Quaternion.identity);
            }
            if (value > 33 && value < 66)
            {
                Instantiate(Chunk2, spawn, Quaternion.identity);
            }
            if (value >= 66)
            {
                Instantiate(Chunk3, spawn, Quaternion.identity);
            }
            
        }
    }
}
