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
    public float grounded;
    public float jumpDuration;
    public float slideDuration;
    public float jumpSpeed;
    public float switchingLaneSpeed;
    private bool isJumping;
    private bool isSliding;

    private void Start()
    {
        m_Player.transform.position = middleAnchor.transform.position;
        isJumping = false;
        isSliding = false;
    }

    private void OnEnable()
    {
        switchLane.action.Enable();
        switchLane.action.performed += SwitchingLane;
        jump.action.Enable();
        jump.action.performed += Jumping;
        slide.action.Enable();
        slide.action.performed += Sliding;
    }
    private void OnDisable()
    {

        switchLane.action.performed -= SwitchingLane;
        switchLane.action.Disable();
        jump.action.performed -= Jumping;
        jump.action.Disable();
        slide.action.performed -= Sliding;
        slide.action.Disable();
    }
    private void Update()
    {
        playerCurrentPosition.x = Mathf.Lerp(playerCurrentPosition.x, targetLane.x, switchingLaneSpeed * Time.deltaTime);
        transform.position = playerCurrentPosition;
        if (isJumping == true)
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, targetJump.y, (jumpSpeed * Time.deltaTime));
        }
        if (isJumping == false)
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, grounded, (jumpSpeed * Time.deltaTime));
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
        if (isSliding == true) { return; }
        if (isJumping == true) { return; }
        if (m_Player.transform.position.y <= 0.5f)
        {
            isJumping = true;
            Debug.Log("jumpInput");
            targetJump.y = heightAnchor.transform.position.y;
            StartCoroutine(EndJump());
        }
        else return;
           
    }
    private IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpDuration);
        isJumping = false;
    }
    private void Sliding(InputAction.CallbackContext context)
    {
        if (isJumping == true) { return; }
        if (isSliding == true) { return; }
            isSliding = true;
            Debug.Log("Slide Input");
       StartCoroutine(EndSlide());
       
    }
    private IEnumerator EndSlide()
    {
        m_Player.transform.rotation = new Quaternion(-90f, 0, 0, 90);
        yield return new WaitForSeconds(slideDuration);
        m_Player.transform.rotation = Quaternion.identity;
        isSliding = false;
    }
}
