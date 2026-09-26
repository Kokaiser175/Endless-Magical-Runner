using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "Corridor_Position", menuName = "Corridor_Position")]
public class SSO_PlayerMovements : ScriptableObject
{
    public Vector2 rightCorridor;
    public Vector2 leftCorridor;
    public Vector2 middleCorridor;
    public float switchBetweenLaneSpeed = 0.3f;
    public float jumpHeight = 10f;
    public float jumpSpeed = 0.3f;
    public float jumpDuration = 2f;
}

