using System.Collections;
using UnityEngine;

public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject Chunk1;
    [SerializeField] GameObject Chunk2;
    [SerializeField] GameObject Chunk3;
    [SerializeField] GameObject Chunk4;
    [SerializeField] GameObject Chunk5;
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
            
            if (value <= 20)
            {
                Instantiate(Chunk1, spawn, Quaternion.identity);
            }
            if (value > 20 && value <= 39)
            {
                Instantiate(Chunk2, spawn, Quaternion.identity);
            }
            if (value >= 40 && value <= 69)
            {
                Instantiate(Chunk3, spawn, Quaternion.identity);
            }
            if (value >= 70 && value <= 89)
            {
                Instantiate(Chunk4, spawn, Quaternion.identity);
            }
            if (value >= 90 && value <= 100)
            {
                Instantiate(Chunk5, spawn, Quaternion.identity);
            }

        }
    }
}
