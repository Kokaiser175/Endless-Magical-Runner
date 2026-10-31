using TMPro;
using UnityEngine;

public class Mana_Display : MonoBehaviour
{
    [SerializeField] private RSO_Mana m_Mana;
    [SerializeField] private TextMeshProUGUI m_Manatxt;

    private void OnEnable() // Abonnement / Désabonnement pour la mise à jour du score.
    {
        m_Mana.OnManaChanged += OnManaChanged;
    }
    private void OnDisable()
    {
        m_Mana.OnManaChanged -= OnManaChanged;
    }
    private void OnManaChanged(int value)
    {
        m_Manatxt.text = value.ToString(); // Charge l'affichage au moment du changement de valeur.
        if (m_Mana.Value > 100)
        {
            m_Mana.Value = 100;
        }
    }
}
