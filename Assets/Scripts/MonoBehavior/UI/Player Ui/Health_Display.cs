using TMPro;
using UnityEngine;

public class Health_Display : MonoBehaviour
{
    [SerializeField] private RSO_Health m_Health;
    [SerializeField] private TextMeshProUGUI m_Healthtxt;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour de la vie du joueur.
    {
        m_Health.OnHealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        m_Health.OnHealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(int value)
    {
        m_Healthtxt.text = value.ToString(); // Charge l'affichage au moment du changement de valeur.
        if (m_Health.Value > 3)
        {
            m_Health.Value = 3;
        }
    }
}


