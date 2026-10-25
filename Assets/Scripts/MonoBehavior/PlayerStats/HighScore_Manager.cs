using UnityEngine;

public class HighScore_Manager : MonoBehaviour
{
    [SerializeField] private RSO_Health m_health;
    [SerializeField] private RSO_Score m_PlayerScore;
    [SerializeField] private RSO_HighScore m_NewHighScore;

    private void OnEnable()
    {
        m_health.OnHealthChanged += SaveHighScore; //Abonnement / Désabonnement à la vie du joueur
    }

    private void OnDisable()
    {
        m_health.OnHealthChanged -= SaveHighScore;
    }
    public void SaveHighScore(int health)
    {
        {
            if (m_health.Value <= 0) // à 0 point de vie seulement 
            {
                AddHighScore(m_PlayerScore.Value);
            }
        }
    }
    private void AddHighScore(int score) // Methode pour ajouter le HighScore dans l'Array
    {
        int[] scores = m_NewHighScore.Values;

        for (int i = 0; i < scores.Length; i++) // lecture du tableau
        {
            if (score > scores[i])
            {
                for (int j = scores.Length - 1; j > i; j--) // Lecture des HighScore du plus haut au plus bas
                {
                    scores[j] = scores[j - 1];
                }

                scores[i] = score;
                m_NewHighScore.SetHighScores(scores); // Mise à jour du classement au changement de valeur.
                break;
            }
        }
    }
} 
