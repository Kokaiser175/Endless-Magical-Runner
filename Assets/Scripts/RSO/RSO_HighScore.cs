using System;
using UnityEngine;
[CreateAssetMenu(fileName = "HighScore", menuName = "HighScore")]
public class RSO_HighScore : ScriptableObject
{
    public event Action<int> OnChanged;
    private int m_Value;
    public int Value
    {
        get { return m_Value; }
        set
        {
            m_Value = value;
            OnChanged?.Invoke(value);
        }
    }
}


