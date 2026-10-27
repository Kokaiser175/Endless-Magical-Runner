using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] RSO_HighScore m_HighScore;
    [SerializeField] RSO_Health m_health;
    [SerializeField] RSO_FireSpellUpgrade m_FireSpellUpgrade;

    private string SavePath => Path.Combine(Application.persistentDataPath, "highscore.json"); // On définit l'emplacement du fichier JSON où les sauvegardes se font. (=> veut dire "Quand on a besoin de SavePath on retourne le chemin)

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
        Debug.Log(SavePath);
        SaveData data = new SaveData();
        data.highScore = m_HighScore.Values; // On sauvegarde les valeurs des HighScores
        data.fireSpellUpdgrade = m_FireSpellUpgrade.Value; // On sauvegarde la valeur de l'augmentation de l'amélioration du spell.
        string json = JsonUtility.ToJson(data, true); // On convertit les données pour le JSON
        File.WriteAllText(SavePath, json); // On les écrit dans le fichier. 

        Debug.Log("HighScores sauvegardés dans : " + SavePath);
    }
}

