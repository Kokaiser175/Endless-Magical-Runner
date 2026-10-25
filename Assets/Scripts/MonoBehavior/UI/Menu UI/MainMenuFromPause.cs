using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

    public class MainMenuFromPause : MonoBehaviour, IPointerClickHandler
    {
    [SerializeField] GameObject PausePanel;
        public void OnPointerClick(PointerEventData eventData)
        {
            PausePanel.SetActive(false);
            Debug.Log("Reset");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); // Recharge complètement la scène MainMenu
        }
    }

