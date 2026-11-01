using UnityEngine;

public class InfoImageManager : MonoBehaviour
{
    [SerializeField] private GameObject m_InfoImage;
    private bool panelIsInactive;

    private void Start()
    {
        m_InfoImage.SetActive(false);
        panelIsInactive = true;
    }
    public void OpenInfoFire()
    {
        if (panelIsInactive == true)
        {
            Debug.Log("m_InfoImage");
            m_InfoImage.SetActive(true);
            panelIsInactive = false;
        }
    }
    public void CloseInfoFirel()
    {
        if (panelIsInactive == false)
        {
            m_InfoImage.SetActive(false);
            panelIsInactive = true;
        }
    }
}

