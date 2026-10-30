using UnityEngine;

public class CloseControl : MonoBehaviour
{
    [SerializeField] private GameObject m_ControlPanel;

    public void CloseSpellBookButton()
    {
        m_ControlPanel.SetActive(false);
    }

}
