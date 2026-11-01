using UnityEngine;

public class ChunkMovement : MonoBehaviour
{
    [SerializeField] private GameObject m_DungeonChunk;
 
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;


    void Update()
    {
        ChunkSpeed(); 
    }
    private void ChunkSpeed()
    {
        m_DungeonChunk.transform.Translate(new Vector3(0, 0, -1f) * m_AccelerationValue.value * Time.deltaTime); // On fait avancer le chunk en fonction de la valeur d'acceleration contenu dans le RSO AccelerationValue.

    }
   

}
