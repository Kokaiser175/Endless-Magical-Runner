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
        m_AccelerationValue.value = 5f;
        StartCoroutine(AccelarationCoroutine());
        
    }

    private IEnumerator AccelarationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            m_AccelerationValue.value = m_AccelerationValue.value + add_Speed;
            if (m_AccelerationValue.value >= 15.8f)
            {
                break;
            }
        }
    }
}
