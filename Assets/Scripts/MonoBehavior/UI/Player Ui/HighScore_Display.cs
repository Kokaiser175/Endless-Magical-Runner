using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HighScore_Display : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_HighScoreTxt;
    [SerializeField] RSO_Score m_PlayerScore;
    [SerializeField] RSO_Health m_health;
    private int m_HighScore;

    public void Start()
    {
            Debug.Log("HighScore");
            m_PlayerScore.Value = m_HighScore;
            m_HighScoreTxt.text = m_HighScore.ToString(); // Si la vie du joueur atteint 0 le HighScore est chargé sur le tableau des scores de la scène GameOver.
    }

}
