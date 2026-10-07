using System;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerScore", menuName = "Score")]

public class RSO_Score : ScriptableObject
{
    public event Action<int> OnChanged;
    private int m_value;
    public int Value
    {
        get { return m_value; }
        set
        {
            m_value = value;
            OnChanged?.Invoke(value);
        }
    }
}
