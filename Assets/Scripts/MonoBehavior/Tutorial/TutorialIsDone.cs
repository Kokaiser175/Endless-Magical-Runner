using UnityEngine;

public class TutorialIsDone : MonoBehaviour
{
    [SerializeField] RSO_Tutorial m_TutoriaState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TutoriaState.tutorialIsDone = true;
    }
    

}
