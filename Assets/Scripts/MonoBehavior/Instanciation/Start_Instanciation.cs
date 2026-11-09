using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.TMP_Compatibility;

public class Start_Instanciation : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_DungeonChunkTuto1;
    [SerializeField] GameObject m_DungeonChunkTuto2;
    [SerializeField] RSO_Tutorial m_TutoriaState;
    [SerializeField] private GameObject[] m_Chunk;

    private void Awake()
    {
        Instantiate(m_Player); // Instancie le joueur.
        
    }
    private void Start()
    {
        if (m_TutoriaState.tutorialIsDone == false)
        {
            Instantiate(m_DungeonChunkTuto1, new Vector3(0f, -0.5f, 0f), Quaternion.identity); // Instancie le chunk de départ
            Instantiate(m_DungeonChunkTuto2, new Vector3(0f, -0.5f, 100f), Quaternion.identity);
        }
        if (m_TutoriaState.tutorialIsDone == true)
        {
            SpawnChunk1();
            SpawnChunk2();
        }
        SpawnChunk3();
        SpawnChunk4();
    }
    private void SpawnChunk1() // On instancie le Chunk. 
    {
        int randomIndex = Random.Range(0, m_Chunk.Length); 
        GameObject selectedChunk = m_Chunk[randomIndex];
        Instantiate(selectedChunk, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
    }
    private void SpawnChunk2() // On instancie le Chunk. 
    {
        int randomIndex = Random.Range(0, m_Chunk.Length);
        GameObject selectedChunk = m_Chunk[randomIndex];
        Instantiate(selectedChunk, new Vector3(0f, -0.5f, 100f), Quaternion.identity);
    }
    private void SpawnChunk3() // On instancie le Chunk. 
    {
        int randomIndex = Random.Range(0, m_Chunk.Length);
        GameObject selectedChunk = m_Chunk[randomIndex];
        Instantiate(selectedChunk, new Vector3(0f, -0.5f, 200f), Quaternion.identity);
    }
    private void SpawnChunk4() // On instancie le Chunk. 
    {
        int randomIndex = Random.Range(0, m_Chunk.Length);
        GameObject selectedChunk = m_Chunk[randomIndex];
        Instantiate(selectedChunk, new Vector3(0f, -0.5f, 300f), Quaternion.identity);
    }
}

