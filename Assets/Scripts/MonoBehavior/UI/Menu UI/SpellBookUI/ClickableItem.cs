using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Objet cliqué : " + gameObject.name);

        // Action à effectuer au clic
        OnObjectClicked();
    }

    private void OnObjectClicked()
    {
        Debug.Log("Action déclenchée !");
    }
}

