using UnityEngine;

public class Start_Instanciation : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_DungeonChunk;

    private void Start()
    {
        Instantiate(m_Player);
        Instantiate(m_DungeonChunk, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
    }
}
