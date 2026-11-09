using UnityEngine;

public class SetTutorialAvailableAgain : MonoBehaviour
{
    [SerializeField] RSO_Tutorial m_TutorialState;

    public void GoToLearnAgain()
    {
        m_TutorialState.tutorialIsDone = false;
    }
}
