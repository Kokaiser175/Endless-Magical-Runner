using UnityEngine;

public class PotionPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject m_PotionPanel;
    private bool panelIsInactive;

    private void Start()
    {
        m_PotionPanel.SetActive(false);
        panelIsInactive = true;
    }
    public void OpenPotion()
    {
        if (panelIsInactive == true)
        {
            Debug.Log("Potion Clicked");
            m_PotionPanel.SetActive(true);
            panelIsInactive = false;
        }
    }
    public void ClosePotion()
    {
        if (panelIsInactive == false)
        {
            m_PotionPanel.SetActive(false);
            panelIsInactive = true;
        }
    }
}
