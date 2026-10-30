using UnityEngine;

public class ControlPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject m_ControlPanel;
    private bool panelIsInactive;

    private void Start()
    {
        m_ControlPanel.SetActive(false);
        panelIsInactive = true;
    }
    public void OpenControl()
    {
        if (panelIsInactive == true)
        {
            Debug.Log("Control Clicked");
            m_ControlPanel.SetActive(true);
            panelIsInactive = false;
        }
    }
    public void CloseControl()
    {
        if (panelIsInactive == false)
        {
            m_ControlPanel.SetActive(false);
            panelIsInactive = true;
        }
    }
}
