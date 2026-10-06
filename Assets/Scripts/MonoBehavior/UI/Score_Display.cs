using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score_Display : MonoBehaviour
{
    [SerializeField] private RSO_Score m_Score;
    [SerializeField] private TextMeshProUGUI m_NewScore;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour du score.
    {
        m_Score.OnChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        m_Score.OnChanged -= OnScoreChanged;
    }
    private void OnScoreChanged(int Value)
    {  
            m_NewScore.text = m_Score.value.ToString(); // Charge l'affichage au moment du changement de valeur.
    }
}
