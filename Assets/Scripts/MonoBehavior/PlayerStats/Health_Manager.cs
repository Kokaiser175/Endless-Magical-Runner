using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] RSO_Health m_Health;

    private void Start()
    {
        m_Health.Value = 3; // La valeur de vie est de trois au lancement de la partie.
        if (m_Health.Value >= 3)
        {
            m_Health.Value = 3;
        }
    }
}


