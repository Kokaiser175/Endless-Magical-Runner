using UnityEngine;

public class Start_Instanciation : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_DungeonChunk;
    [SerializeField] GameObject m_SpawnPosition;

    private void Awake()
    {
        Instantiate(m_Player); // Instancie le joueur.
    }
    private void Start()
    {
        Instantiate(m_DungeonChunk, new Vector3(0f, -0.5f, 0f), Quaternion.identity); // Instancie le chunk de départ
        Instantiate(m_DungeonChunk, new Vector3(0f, -0.5f, 100f), Quaternion.identity);
        Instantiate(m_DungeonChunk, new Vector3(0f, -0.5f, 200f), Quaternion.identity);
        Instantiate(m_DungeonChunk, new Vector3(0f, -0.5f, 300f), Quaternion.identity);

    }
}
