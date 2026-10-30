using UnityEngine;

public class FireSpellIsUpgrade : MonoBehaviour
{
    [SerializeField] RSO_FireSpellUpgrade m_FireSpellUpdate;
    [SerializeField] RSO_SpellValue m_NewFireSpellValue;

    public void Start()
    {
        if (m_FireSpellUpdate.Value < 25)
        {
            m_NewFireSpellValue.spellEffectValue = 5;
            m_NewFireSpellValue.spellManaCost = 30;
        }
        if (m_FireSpellUpdate.Value >= 25)
        {
            Debug.Log("Fire Spell is Up");
            m_NewFireSpellValue.spellEffectValue = 7;
            m_NewFireSpellValue.spellManaCost = 25;
        }
    }
}
