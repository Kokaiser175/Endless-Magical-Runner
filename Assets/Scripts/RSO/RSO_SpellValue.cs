using UnityEngine;
[CreateAssetMenu(fileName = "Spell", menuName = "Player_Spell")]
public class RSO_SpellValue : ScriptableObject
{
    public float spellDuration;
    public int spellManaCost;
    public float spellCoolDowm;
    public bool spellIsActive;
    public bool cooldownIsActive;
    public int spellEffectCount;
}
