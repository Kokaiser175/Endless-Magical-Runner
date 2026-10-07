using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WorldSpeedAcceleration : MonoBehaviour
{
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;
    public float add_Speed;
    void Start()
    {
        add_Speed = 0.25f;
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
            m_AccelerationValue.value = m_AccelerationValue.value + add_Speed;
        }
    }
}
