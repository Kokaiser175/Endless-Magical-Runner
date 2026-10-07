using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Transform leftAnchor;
    [SerializeField] Transform middleAnchor;
    [SerializeField] Transform rightAnchor;
    [SerializeField] Transform heightAnchor;
    [SerializeField] GameObject m_Player;
    [SerializeField] InputActionReference switchLane;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference slide;
    public Vector3 playerCurrentPosition;
    private Vector3 targetLane;
    private Vector3 targetJump;
    private int currentCorridor; // -1 = left; 0 = middle ; 1 = right.
    public float grounded = 0f;
    public float jumpDuration = 0.8f;
    public float jumpSpeed = 10f;
    public float switchingLaneSpeed = 5f;
    private bool isJumping;

    private void Start()
    {
        m_Player.transform.position = middleAnchor.transform.position;
        isJumping = false;
    }

    private void OnEnable()
    {
        switchLane.action.Enable();
        switchLane.action.performed += SwitchingLane;
        jump.action.Enable();
        jump.action.performed += Jumping;

    }
    private void OnDisable()
    {

        switchLane.action.performed -= SwitchingLane;
        switchLane.action.Disable();
        jump.action.performed -= Jumping;
        jump.action.Disable();
    }
    private void Update()
    {
        playerCurrentPosition.x = Mathf.Lerp(playerCurrentPosition.x, targetLane.x, switchingLaneSpeed * Time.deltaTime);
        m_Player.transform.position = playerCurrentPosition;
        if (isJumping == true)
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, targetJump.y, jumpSpeed * Time.deltaTime);
        }
        if (isJumping == false)
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, grounded, jumpSpeed * Time.deltaTime);
        }
    }

    private void SwitchingLane(InputAction.CallbackContext context)
    {
        Debug.Log("InputActivé");
        float input = context.ReadValue<Vector2>().x; // Lecture de la valeur X de l'input uniquement

        if (input < 0)
        {
            currentCorridor--;
            if (currentCorridor < -1) { currentCorridor = -1; }
        }
        if (input > 0)
        {
            currentCorridor++;
            if (currentCorridor > 1) { currentCorridor = 1; } // On verouille la valeur pour ne pas dépasser -1 ou 1.
        }
        if (currentCorridor == -1)
        {
            targetLane.x = leftAnchor.transform.position.x;  // déplacement sur le couloir avec la valeur de l'int currentCorridor

        }
        if (currentCorridor == 0)
        {
            targetLane.x = middleAnchor.transform.position.x;

        }
        if (currentCorridor == 1)
        {
            targetLane.x = rightAnchor.transform.position.x;

        }
    }
    private void Jumping(InputAction.CallbackContext context)
    {
        if (isJumping == true) { return; }
        isJumping = true;
        Debug.Log("jumpInput");
        targetJump.y = heightAnchor.transform.position.y;
        StartCoroutine(EndJump());
    }
    private IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpDuration);
        isJumping=false;
        
    }
  

}
