using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    [SerializeField] private GameObject m_TutorialPanel;

    public void CloseInfoFireButton()
    {
        m_TutorialPanel.SetActive(false);
    }
}
