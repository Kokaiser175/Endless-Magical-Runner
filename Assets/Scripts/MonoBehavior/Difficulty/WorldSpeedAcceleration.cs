using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class WorldSpeedAcceleration : MonoBehaviour
{
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;
    [SerializeField] public Camera m_Camera;
    public float add_Speed;
    public float m_AddPitch;
    AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = m_Camera.GetComponent<AudioSource>();
        m_AudioSource.pitch = 1;
        m_AddPitch = 0.0005f;
        m_AccelerationValue.value = 10f;
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
                m_AudioSource.pitch += m_AddPitch;
                add_Speed = 0.2f;
            }
            if (m_AccelerationValue.value > 25.8f)
            {
                m_Camera.GetComponents<AudioSource>();
                m_AudioSource.pitch += 0f;
                add_Speed = 0;
            }
        }
    }
}
