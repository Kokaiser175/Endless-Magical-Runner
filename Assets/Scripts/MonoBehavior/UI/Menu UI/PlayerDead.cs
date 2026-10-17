using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] RSO_Health m_health;
    public void PlayerisDead(int health)
    {
        health = m_health.m_value;
        if (health == 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); // Charge le GameOver
        }
    }
}
