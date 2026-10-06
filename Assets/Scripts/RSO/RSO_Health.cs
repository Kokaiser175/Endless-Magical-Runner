using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealth", menuName = "Player_Health")]

public class RSO_Health : ScriptableObject
{
    public event Action<int> OnHealthChanged;
    private int m_value;
    public int Value
    {
        get { return m_value; }
        set
        {
            m_value = value;
            OnHealthChanged?.Invoke(value);
        }
    }
}
