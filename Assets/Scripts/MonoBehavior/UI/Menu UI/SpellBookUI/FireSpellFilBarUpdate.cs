using UnityEngine;
using UnityEngine.UI;

public class SpellFilBarUpdate : MonoBehaviour
{
    [SerializeField] RSO_FireSpellUpgrade m_FireSpellUpdate;
    [SerializeField] Image m_FireSpellFillBar;
    private int m_MaxBar = 25;
    private void OnEnable()
    {
        m_FireSpellUpdate.OnChanged += UdpateFireSpellBar; //Abonnement / Désabonnement à la vie du joueur
        UdpateFireSpellBar(m_FireSpellUpdate.Value);
    }

    private void OnDisable()
    {
        m_FireSpellUpdate.OnChanged -= UdpateFireSpellBar;
    }
 
    public void UdpateFireSpellBar(int value)
    {
        m_FireSpellFillBar.fillAmount = (float)m_FireSpellUpdate.Value / m_MaxBar;
    }
    
}
