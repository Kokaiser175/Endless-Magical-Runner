using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMana", menuName = "Player_Mana")]
public class RSO_Mana : ScriptableObject
{
    public event Action<int> OnManaChanged;
    public int m_value;
    public int Value
    {
        get { return m_value; }
        set
        {
            m_value = value;
            OnManaChanged?.Invoke(value);
        }
    }
}

