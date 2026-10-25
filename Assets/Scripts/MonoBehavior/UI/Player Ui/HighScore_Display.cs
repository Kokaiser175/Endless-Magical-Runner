using TMPro;
using UnityEngine;

public class HighScore_Display : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI [] m_HighScoreTxt;
    [SerializeField] RSO_HighScore m_PlayerHighScore;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour du score.
    {
        m_PlayerHighScore.OnChanged += OnHighScoreChanged;
        OnHighScoreChanged(m_PlayerHighScore.Values); // Affiche la valeur déja enregistrée dans le RSO
    }
    private void OnDisable()
    {
        m_PlayerHighScore.OnChanged -= OnHighScoreChanged;
    }
    public void OnHighScoreChanged(int[] value)
    {
        for (int i = 0; i < m_HighScoreTxt.Length; i++)
        {
            m_HighScoreTxt[i].text = (i + 1) + ". " + value[i]; // Affiche la valeur du HighScore dans le TMP.
        }  
    }

}
