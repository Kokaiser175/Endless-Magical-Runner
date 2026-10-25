using UnityEngine;

public class HighScore_Manager : MonoBehaviour
{
    [SerializeField] private RSO_Health m_health;
    [SerializeField] private RSO_Score m_PlayerScore;
    [SerializeField] private RSO_HighScore m_NewHighScore;

    private void OnEnable()
    {
        m_health.OnHealthChanged += SaveHighScore;
    }

    private void OnDisable()
    {
        m_health.OnHealthChanged -= SaveHighScore;
    }
    public void SaveHighScore(int health)
    {
        {
            if (m_health.Value <= 0)
            {
                m_NewHighScore.Value = m_PlayerScore.Value;
            }
        }
    }

} 
