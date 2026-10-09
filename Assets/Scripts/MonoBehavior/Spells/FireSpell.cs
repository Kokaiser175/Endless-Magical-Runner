using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FireSpell : MonoBehaviour
{
    [SerializeField] RSO_SpellValue fire;
    [SerializeField] InputActionReference castSpell;
    [SerializeField] RSO_AccelerationValue speedAcceleration;
    [SerializeField] RSO_Mana manaCost;
    [SerializeField] Material FireEffectMaterial;
    [SerializeField] Material WizardMaterial;
    [SerializeField] GameObject m_Player;

    private void Start()
    {
        fire.spellIsActive = false;
    }

    private void OnEnable()
    {
        castSpell.action.Enable();
        castSpell.action.performed += CastFireSpell;
    }
    private void OnDisable()
    {
        castSpell.action.performed -= CastFireSpell;
        castSpell.action.Disable();
    }

    public void CastFireSpell(InputAction.CallbackContext context)
    {
        if (manaCost.Value < fire.spellManaCost) { return; }
        if (manaCost.Value >= fire.spellManaCost)
        {
            fire.spellIsActive = true;
            manaCost.Value = manaCost.Value - fire.spellManaCost;
            if (fire.spellIsActive == true)
            {
                FireSpellEffect();
                StartCoroutine(FireSpellCoroutine());
            }
        }
       
    }
    private IEnumerator FireSpellCoroutine()
    {
        yield return new WaitForSeconds(fire.spellDuration);
        m_Player.GetComponentInChildren<SkinnedMeshRenderer>().material = WizardMaterial;
        speedAcceleration.value = speedAcceleration.value * 0.8f;
        fire.spellIsActive = false;

    }
    private void FireSpellEffect()
    {
        
        m_Player.GetComponentInChildren<SkinnedMeshRenderer>().material = FireEffectMaterial;
        speedAcceleration.value = speedAcceleration.value * 1.2f;
        
    }
}
