using System.Collections;
using UnityEngine;

public class WorldSpeedAcceleration : MonoBehaviour
{
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;
    public float add_Speed;
    void Start()
    {
        m_AccelerationValue.value = 8f;
        StartCoroutine(AccelarationCoroutine());
    }

    private IEnumerator AccelarationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            m_AccelerationValue.value = m_AccelerationValue.value + add_Speed;
            if (m_AccelerationValue.value < 23.8f)
            {
                add_Speed = 0.2f;
            }
            if (m_AccelerationValue.value > 23.8f)
            {
                add_Speed = 0;
            }
        }
    }
}
