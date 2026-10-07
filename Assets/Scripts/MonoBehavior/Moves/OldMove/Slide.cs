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
    private void StartSlide(InputAction.CallbackContext jump)
    {
        
    }
 

    
}
