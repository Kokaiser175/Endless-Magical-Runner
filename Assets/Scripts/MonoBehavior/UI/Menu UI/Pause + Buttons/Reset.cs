using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Reset");
        SceneManager.LoadScene("RunnerGame", LoadSceneMode.Single); // Recharge complètement la scène GameSnake
    }
}
