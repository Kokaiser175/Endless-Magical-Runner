using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [SerializeField] RSO_HighScore m_HighScore;
    private string SavePath => Path.Combine(Application.persistentDataPath, "highscore.json"); // On définit l'emplacement du fichier JSON où les sauvegardes se font. (=> veut dire "Quand on a besoin de SavePath on retourne le chemin)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load();
    }
    public void Load()
    {
        if (!File.Exists(SavePath)) // Si la sauvegarde n'existe pas on ne charge pas
        {
            Debug.Log("Aucune sauvegarde trouvée.");
            return;
        }

        string json = File.ReadAllText(SavePath); // On lit le contenu du fichier
        SaveData data = JsonUtility.FromJson<SaveData>(json); // On convertit le JSON en objet SaveData

        if (data != null && data.highScore != null && data.highScore.Length == 3)
        {
            m_HighScore.SetHighScores(data.highScore); // On applique les scores au chargement
            Debug.Log("HighScores chargés !");
        }
    }
}

