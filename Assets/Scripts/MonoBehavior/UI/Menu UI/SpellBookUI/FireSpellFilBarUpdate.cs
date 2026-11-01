using UnityEngine;
using UnityEngine.UI;

public class SpellFilBarUpdate : MonoBehaviour
{
    [SerializeField] RSO_FireSpellUpgrade m_FireSpellUpdate;
    [SerializeField] Image m_FireSpellFillBar;
    private int m_MaxBar;
    private void OnEnable()
    {
        m_FireSpellUpdate.OnChanged += UdpateFireSpellBar; //Abonnement / Désabonnement à la vie du joueur
        UdpateFireSpellBar(m_FireSpellUpdate.Value);
    }

    private void OnDisable()
    {
        m_FireSpellUpdate.OnChanged -= UdpateFireSpellBar;
    }
 
    public void UdpateFireSpellBar(int value) // La taille de la barre à remplir augmente en fonction de l'amélioration du sort.
    {
        if (m_FireSpellUpdate.Value <= 10)
        {
            m_MaxBar = 10;
            m_FireSpellFillBar.fillAmount = (float)m_FireSpellUpdate.Value / m_MaxBar;
        }
        if (m_FireSpellUpdate.Value >= 11 && m_FireSpellUpdate.Value <= 25)
        {
            m_MaxBar = 25;
            m_FireSpellFillBar.fillAmount = (float)m_FireSpellUpdate.Value / m_MaxBar;
        }
        if (m_FireSpellUpdate.Value >= 26 && m_FireSpellUpdate.Value <= 45)
        {
            m_MaxBar = 45;
            m_FireSpellFillBar.fillAmount = (float)m_FireSpellUpdate.Value / m_MaxBar;
        }
        if (m_FireSpellUpdate.Value >= 46 && m_FireSpellUpdate.Value <= 70)
        {
            m_MaxBar = 70;
            m_FireSpellFillBar.fillAmount = (float)m_FireSpellUpdate.Value / m_MaxBar;
        }

    }
    
}
