using System;
using UnityEngine;

public abstract class RSE_Score<T> : ScriptableObject
{
    public event Action<T> OnChanged;
    public T value;
    public T Value
    {
        get { return value; }
        set
        {
            Debug.Log("ScoreUp");
            Value = value;
            OnChanged?.Invoke(value);
        }
    }
}
