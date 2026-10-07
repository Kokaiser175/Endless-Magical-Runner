using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{   
    [SerializeField] private RSO_MovementValue m_JumpAction;
    [SerializeField] private InputActionReference m_JumpInput;
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        m_JumpInput.action.Enable();
        m_JumpInput.action.performed += StartJump;
    }
    private void OnDisable()
    {
        m_JumpInput.action.performed -= StartJump;
        m_JumpInput.action.Enable();
    }

    private void StartJump(InputAction.CallbackContext jump)
    {
        m_JumpAction.grounded = Mathf.Lerp(m_JumpAction.grounded, m_JumpAction.jumpHightTarget, m_JumpAction.jumpForce * Time.deltaTime);

        if (m_JumpAction.grounded >= m_JumpAction.jumpHightTarget)
        {
            m_JumpAction.grounded = Mathf.Lerp(m_JumpAction.jumpHightTarget, m_JumpAction.grounded, m_JumpAction.jumpForce * Time.deltaTime);
        }
    }
}
