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
        m_AudioSource = m_Camera.GetComponent<AudioSource>(); // On assigne l'audio source de la caméra à une variable pour ne pas rechercher le composant à chaque fois. 
        m_AudioSource.pitch = 1; // Le pitch est à 1 au démarrage de la partie. 
        m_AddPitch = 0.0003f; // Valeur d'augmentation du pitch
        m_AccelerationValue.value = 10f; // Valeur d'augmentation de vitesse.
        StartCoroutine(AccelarationCoroutine()); // On lance la coroutine au démarrage. 
    }
    private IEnumerator AccelarationCoroutine() // Coroutine pour augmenter la vitesse générale du jeu. 
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Chaque seconde on ajoute vitesse et pitch. 
            m_AccelerationValue.value = m_AccelerationValue.value + add_Speed;
            if (m_AccelerationValue.value < 23.8f)
            {
                m_AudioSource.pitch += m_AddPitch;
                add_Speed = 0.2f;
            }
            if (m_AccelerationValue.value > 25.8f) // à la valeur max on bloque l'augmentation.
            {
                m_AudioSource.pitch += 0f;
                add_Speed = 0;
            }
        }
    }
}
