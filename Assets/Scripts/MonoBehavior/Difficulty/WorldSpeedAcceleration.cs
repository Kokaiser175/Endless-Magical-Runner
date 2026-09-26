using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WorldSpeedAcceleration : MonoBehaviour
{
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;
    void Start()
    {
        m_AccelerationValue.value = 3f;
        StartCoroutine(AccelarationCoroutine());
        if (m_AccelerationValue.value >= 16f)
        {
            m_AccelerationValue.value = 16f;
        }
    }

    private IEnumerator AccelarationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            m_AccelerationValue.value = m_AccelerationValue.value + 0.25f;
        }
            
    }

}
