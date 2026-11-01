using UnityEngine;

public class CloseInfo : MonoBehaviour
{
    [SerializeField] private GameObject m_InfoImage;

    public void CloseInfoFireButton()
    {
        m_InfoImage.SetActive(false);
    }

}
