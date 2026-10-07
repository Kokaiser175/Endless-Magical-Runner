using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "Corridor_Position", menuName = "Corridor_Position")]
public class SSO_PlayerMovements : ScriptableObject
{
    public Vector3 rightCorridor;
    public Vector3 leftCorridor;
    public Vector3 middleCorridor;
}

