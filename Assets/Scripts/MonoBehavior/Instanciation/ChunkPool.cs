using System.Collections.Generic;
using UnityEngine;


public class ChunkPool : MonoBehaviour
{
    [SerializeField] GameObject m_ChunkPrefab;
    [SerializeField] private int m_amount;

    private List<GameObject> m_ChunkPool;

    private void InitializeChunkPool()
    {
        m_ChunkPool = new List<GameObject>();
        for (int i = 0; i < m_ChunkPool.Count; i++)
        {
            GameObject chunk = Instantiate(m_ChunkPrefab, transform);
            chunk.SetActive(false);
            m_ChunkPool.Add(chunk);
        }

    }
}
