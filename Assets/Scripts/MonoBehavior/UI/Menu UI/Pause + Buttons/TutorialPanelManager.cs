using UnityEngine;

public class TutorialPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject m_TutorialPanel;
    [SerializeField] RSO_Tutorial m_TutorialState;
    private bool panelIsInactive;

    private void Start()
    {
        m_TutorialPanel.SetActive(false);
        panelIsInactive = true;
    }
    public void OpenTutorial()
    {
        if (panelIsInactive == true)
        {
            Debug.Log("Potion Clicked");
            m_TutorialPanel.SetActive(true);
            panelIsInactive = false;
        }
    }
    public void CloseTutorial()
    {
        if (panelIsInactive == false)
        {
            m_TutorialPanel.SetActive(false);
            panelIsInactive = true;
        }
    }
    public void GoToLearnAgain()
    {
        m_TutorialState.tutorialIsDone = false;
        Debug.Log(m_TutorialState.tutorialIsDone.ToString());
    }
}
