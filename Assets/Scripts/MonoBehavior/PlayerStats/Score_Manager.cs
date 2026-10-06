using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField] RSO_Score m_Value;
    [SerializeField] RSO_AccelerationValue speed;

    private void Update()
    {
        m_Value.Value++;
    }
}
