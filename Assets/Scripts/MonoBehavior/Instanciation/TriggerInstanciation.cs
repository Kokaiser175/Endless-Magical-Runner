using UnityEngine;

public class TriggerInstanciation : MonoBehaviour
{
    [SerializeField] GameObject Chunk1;
    [SerializeField] GameObject Chunk2;
    [SerializeField] GameObject Chunk3;
    private int value;

    private void OnTriggerEnter(Collider other)
    {
        Random.InitState(Random.Range(0,100));
        value = Random.Range(0, 100);

        if (other.gameObject.CompareTag("SpawnTrigger"))
        {
            if (value <= 33)
            {
                Instantiate(Chunk1, new Vector3(0, -0.5f, 92.75f), Quaternion.identity);
            }
            if (value > 33 && value < 66)
            {
                Instantiate(Chunk2, new Vector3(0, -0.5f, 92.75f), Quaternion.identity);
            }
            if (value >= 66)
            {
                Instantiate(Chunk3, new Vector3(0, -0.5f, 92.75f), Quaternion.identity);
            }

        }
    }
}
