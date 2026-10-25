using System;
using UnityEngine;
[CreateAssetMenu(fileName = "HighScore", menuName = "HighScore")]
public class RSO_HighScore : ScriptableObject
{
    public event Action<int[]> OnChanged;

    [SerializeField] private int[] m_Values = new int[3]; // Tableau des scores

    public int[] Values
    {
        get { return m_Values; } //Get les valeurs des HighScore
    }

    public void SetHighScores(int[] values) // Set les valeurs des HighScores
    {
        m_Values = values;
        OnChanged?.Invoke(m_Values);
    }
}


