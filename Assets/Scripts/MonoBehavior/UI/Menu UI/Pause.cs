using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private InputActionReference PauseInput;
    [SerializeField] private InputActionReference endPauseInput;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private RSO_PauseState pause;
    void Start()
    {
        PausePanel.SetActive(false);
        pause.isPaused = false;
    }

    private void OnEnable()
    {
        if (pause.isPaused == false)
        {
            if (pause.isPaused == true) { return; }
            PauseInput.action.Enable();
            PauseInput.action.performed += PauseButtonClicked;
            
        }
        if (pause.isPaused == true)
        {
            if (pause.isPaused == false) { return; }
            endPauseInput.action.Enable();
            endPauseInput.action.performed += EndPause;
            
        }
        
    }
    private void OnDisable()
    {
        if (pause.isPaused == false)
        {
            if (pause.isPaused == true) { return; }
            PauseInput.action.performed -= PauseButtonClicked;
            PauseInput.action.Disable();
            
        }

        if (pause.isPaused == true)
        {
            if (pause.isPaused == false) { return; }
            endPauseInput.action.performed -= EndPause;
            endPauseInput.action.Disable();
            
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
    void EndPause(InputAction.CallbackContext context) // Fin de la pause et reprise normale du temps.
    {
            Debug.Log("Pause Désactivée");
            PausePanel.SetActive(false);
            Time.timeScale = 1.0f;
            pause.isPaused = false;
        if (pause.isPaused == false)
        {
            pause.isPaused = true;
        }
    }
}
