using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Jump : MonoBehaviour
{   
    [SerializeField] private RSO_PlayerRuntime m_JumpAction;
    [SerializeField] private SSO_PlayerMovements m_JumpValue;
    [SerializeField] private InputActionReference m_jumpInput;
<<<<<<< Updated upstream
    [SerializeField] private GameObject m_Player;
=======
>>>>>>> Stashed changes

    private void Start()
    {
        m_JumpAction.grounded = 1.5f;
        m_JumpAction.isGrounded = true;
    }
    private void OnEnable()
    {
        m_jumpInput.action.Enable();
        m_jumpInput.action.performed += StartJump;
    }
    private void OnDisable()
    {
        m_jumpInput.action.performed -= StartJump;
        m_jumpInput.action.Enable();
    }

    private void Update()
    {
        if (m_JumpAction.isGrounded == false)
        {
            Debug.Log("jump");
            m_Player.transform.position += new Vector3(m_Player.transform.position.x, m_JumpAction.grounded, m_Player.transform.position.z) * Time.deltaTime;

            if(m_Player.transform.position == new Vector3(m_Player.transform.position.x, 1.5f, m_Player.transform.position.z))
            {
                m_JumpAction.isGrounded = true;
            }
                
                   
        }
               
    }

    private void StartJump(InputAction.CallbackContext jump)
    {
        if (m_JumpAction.grounded == 0)
        {
            Debug.Log("slide input");
            m_JumpAction.isGrounded = false;
        }
        if (m_JumpAction.grounded < 0) { return; }
    }
}
