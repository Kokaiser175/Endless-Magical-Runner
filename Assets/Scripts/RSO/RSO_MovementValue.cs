using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player_Runtime")]
public class RSO_MovementValue : ScriptableObject
{
    public bool isGrounded;
    public float jumpVelocityForce;
    public float grounded;
    public bool isUnderGround;

}
