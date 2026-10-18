using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] RSO_Health m_health;

    private void OnEnable()
    {
        m_health.OnHealthChanged += PlayerisDead; //Abonnement et désabonnement au RSO_Health pour avoir la valeur du RSO.
    }

    private void OnDisable()
    {
        m_health.OnHealthChanged -= PlayerisDead;
    }
    public void PlayerisDead(int health)
    {
        if (m_health.Value <= 0) // à 0 point de vie le game over se lance.
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver"); // Charge le GameOver
        }
    }
}
