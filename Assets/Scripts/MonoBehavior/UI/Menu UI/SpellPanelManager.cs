using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SpellPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject m_SpellPanel;
    private bool panelIsInactive;

    private void Start()
    {
        m_SpellPanel.SetActive(false);
        panelIsInactive = true;
    }
    public void OpenSpellBook()
    {
        if (panelIsInactive == true)
        {
            Debug.Log("SpellBook Clicked");
            m_SpellPanel.SetActive(true);
            panelIsInactive = false;
        }
    }
    public void CloseSpellBook()
    {
        if (panelIsInactive == false)
        {
            m_SpellPanel.SetActive(false);
            panelIsInactive = true;
        }
    }
}
