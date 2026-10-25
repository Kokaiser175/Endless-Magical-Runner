using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private InputActionReference PauseInput;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private RSO_PauseState pause;
    void Start()
    {
        PausePanel.SetActive(false);
        pause.isPaused = false;
        if (pause.isPaused == false)
        {
            Time.timeScale = 1.0f;
        }
    }

    private void OnEnable()
    {
        if (pause.isPaused == false)
        {
            PauseInput.action.Enable();
            PauseInput.action.performed += PauseButtonClicked;
            
        }
        
    }
    private void OnDisable()
    {
        if (pause.isPaused == false)
        {
            PauseInput.action.performed -= PauseButtonClicked;
            PauseInput.action.Disable();
            
        }
    }

    void PauseButtonClicked(InputAction.CallbackContext context) // Pause en arrêtant le temps (ZAWALOUDO)
    {
            Debug.Log("Pause Activée");
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
            if (pause.isPaused == true)
        {
            pause.isPaused = false;
        }
    }

}
