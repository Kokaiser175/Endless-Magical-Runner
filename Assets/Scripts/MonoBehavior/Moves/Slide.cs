using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slide : MonoBehaviour
{
        [SerializeField] private RSO_MovementValue m_SlideAction;
        [SerializeField] private SSO_PlayerMovements m_SlideValue;
        [SerializeField] private InputActionReference m_SlideInput;

        private void Start()
        {
            m_SlideAction.isUnderGround = false;
        }
        private void OnEnable()
        {
            m_SlideInput.action.Enable();
            m_SlideInput.action.performed += StartSlide;
        }
        private void OnDisable()
        {
            m_SlideInput.action.performed -= StartSlide;
            m_SlideInput.action.Enable();
        }

        private void Update()
        {
            if (m_SlideAction.isUnderGround == true)
            {
                if (m_SlideAction.grounded == 0f)
                {
                    StartCoroutine(SlideCoroutine());

                }
                else { return; }
                
            }
        }
        private void StartSlide(InputAction.CallbackContext jump)
        { 
        if (m_SlideAction.grounded == 0)
        {
            Debug.Log("slide input");
            m_SlideAction.isUnderGround = true;
        }
        if (m_SlideAction.grounded > 0) { return; }
            
        }
        private IEnumerator SlideCoroutine()
        {
            m_SlideAction.grounded = -1.5f;
            yield return new WaitForSeconds(m_SlideValue.jumpDuration);
            m_SlideAction.isUnderGround = false;
            m_SlideAction.grounded = 0;
        }

    
}
