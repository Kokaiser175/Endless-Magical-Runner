using UnityEngine;
using UnityEngine.EventSystems;

public class CloseSpellBook : MonoBehaviour
{

    [SerializeField] private GameObject spellBookPanel;

    public void CloseSpellBookButton()
    {
        spellBookPanel.SetActive(false);
    }

}

