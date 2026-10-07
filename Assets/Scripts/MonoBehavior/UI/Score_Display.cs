using LitMotion;
using LitMotion.Extensions;
using TMPro;
using UnityEngine;

public class Score_Display : MonoBehaviour
{
    [SerializeField] private RSO_Score m_Score;
    [SerializeField] private TextMeshProUGUI m_Scoretxt;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour du score.
    {
        m_Score.OnChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        m_Score.OnChanged -= OnScoreChanged;
    }
    private void OnScoreChanged(int value)
    {
        m_Scoretxt.text = value.ToString(); // Charge l'affichage au moment du changement de valeur.
    }
}
