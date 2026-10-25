using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class QuitPauseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject PausePanel;


    public void OnPointerClick(PointerEventData eventData)
    {
            PausePanel.SetActive(false);
            Time.timeScale = 1.0f;
    }
}
