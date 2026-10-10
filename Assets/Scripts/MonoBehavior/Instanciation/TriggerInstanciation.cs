using System.Collections;
using UnityEngine;

public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject Chunk1;
    [SerializeField] GameObject Chunk2;
    [SerializeField] GameObject Chunk3;
    private int value;
    public float InstanciationDitance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { return; }

        value = Random.Range(0, 100);
        Debug.Log($"{value.ToString()}");


        if (other.gameObject.CompareTag("SpawnTrigger"))
        {
            
            if (value <= 33)
            {
                Instantiate(Chunk1, new Vector3(0, -0.5f, InstanciationDitance), Quaternion.identity);
            }
            if (value > 33 && value < 66)
            {
                Instantiate(Chunk2, new Vector3(0, -0.5f, InstanciationDitance), Quaternion.identity);
            }
            if (value >= 66)
            {
                Instantiate(Chunk3, new Vector3(0, -0.5f, InstanciationDitance), Quaternion.identity);
            }
            
        }
    }
}
