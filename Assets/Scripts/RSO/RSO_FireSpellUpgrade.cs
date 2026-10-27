using System;
using UnityEngine;
[CreateAssetMenu(fileName = "FireSpellUpgrade", menuName = "Achivement")]
public class RSO_FireSpellUpgrade : ScriptableObject
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
