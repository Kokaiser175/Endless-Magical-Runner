using TMPro;
using UnityEngine;

public class HighScore_Display : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_HighScoreTxt;
    [SerializeField] RSO_HighScore m_PlayerHighScore;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour du score.
    {
        m_PlayerHighScore.OnChanged += OnHighScoreChanged;
        OnHighScoreChanged(m_PlayerHighScore.Value); // Affiche la valeur déja enregistrée dans le RSO
    }
    private void OnDisable()
    {
        m_PlayerHighScore.OnChanged -= OnHighScoreChanged;
    }
    public void OnHighScoreChanged(int value)
    {
            m_HighScoreTxt.text = value.ToString(); // Affiche la valeur du HighScore dans le TMP. 
    }

}
