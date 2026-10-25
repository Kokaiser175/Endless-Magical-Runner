using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Quit : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Leave");
        Application.Quit(); // Quitte, littéralement.
    } 
}
