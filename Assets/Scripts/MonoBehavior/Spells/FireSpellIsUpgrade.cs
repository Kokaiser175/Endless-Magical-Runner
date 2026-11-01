using UnityEngine;

public class FireSpellIsUpgrade : MonoBehaviour
{
    [SerializeField] RSO_FireSpellUpgrade m_FireSpellUpdate;
    [SerializeField] RSO_SpellValue m_NewFireSpellValue;

    public void Start() // On démarrage on vérifie combien de fois le sort de feu est lancé et les valeurs se mettent à jour en fonction de la valeur actuelle. 
    {
        if (m_FireSpellUpdate.Value < 10)
        {
            m_NewFireSpellValue.spellEffectValue = 5;
            m_NewFireSpellValue.spellManaCost = 30;
        }
        if (m_FireSpellUpdate.Value >= 10 && m_FireSpellUpdate.Value <= 24)
        {
            Debug.Log("Fire Spell is Up");
            m_NewFireSpellValue.spellEffectValue = 7;
            m_NewFireSpellValue.spellManaCost = 30;
        }
        if (m_FireSpellUpdate.Value >= 25 && m_FireSpellUpdate.Value <= 44)
        {
            Debug.Log("Fire Spell is Up");
            m_NewFireSpellValue.spellEffectValue = 9;
            m_NewFireSpellValue.spellManaCost = 25;
        }
        if (m_FireSpellUpdate.Value >= 45 && m_FireSpellUpdate.Value <= 69)
        {
            Debug.Log("Fire Spell is Up");
            m_NewFireSpellValue.spellEffectValue = 11;
            m_NewFireSpellValue.spellManaCost = 25;
        }
        if (m_FireSpellUpdate.Value >= 70)
        {
            Debug.Log("Fire Spell is Up");
            m_NewFireSpellValue.spellEffectValue = 11;
            m_NewFireSpellValue.spellManaCost = 25;
        }

    }
}
