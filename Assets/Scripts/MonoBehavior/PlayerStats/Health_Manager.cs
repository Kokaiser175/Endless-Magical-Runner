using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] RSO_Health m_Health;

    void Start()
    {
        m_Health.Value = 3;
        if (m_Health.Value >= 3)
        {
            m_Health.Value = 3;
        }
    }
}


