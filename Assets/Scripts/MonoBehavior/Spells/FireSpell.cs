using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FireSpell : MonoBehaviour
{
    [SerializeField] RSO_SpellValue fire;
    [SerializeField] RSO_ObstacleValues hit;
    [SerializeField] InputActionReference castSpell;
    [SerializeField] RSO_AccelerationValue speedAcceleration;
    [SerializeField] RSO_Mana manaCost;
    [SerializeField] Material FireEffectMaterial;
    [SerializeField] Material WizardMaterial;
    [SerializeField] GameObject m_Player;

    private void Start()
    {
        fire.spellIsActive = false; // booléen pour indiquer que le sort n'est pas actif au lancement d'une partie.
        fire.cooldownIsActive = false; // booléen pour indiquer si le sort est en cours de récupération ou pas. 
    }

    private void OnEnable() // Abonnement/Désabonnement pour l'input qui permet de lancer le sort. 
    {
        castSpell.action.Enable();
        castSpell.action.performed += CastFireSpell; 
    }
    private void OnDisable()
    {
        castSpell.action.performed -= CastFireSpell;
        castSpell.action.Disable();
    }

    public void CastFireSpell(InputAction.CallbackContext context) // Methode pour lancer le sort
    {   
        if (fire.cooldownIsActive == true) { return; } // Si la récupération est active on ne peut pas lancer le sort.
        if (fire.spellIsActive == true) { return; } // Si le sort est actuellement lancé, on ne peut pas lancer le sort.
        if (manaCost.Value < fire.spellManaCost) { return; } // Si le joueur n'a pas assez de mana il ne peut pas lancer le sort. 
        if (manaCost.Value >= fire.spellManaCost) // Si le joueur a assez de mana il peut lancer le sort. 
        {
            fire.spellIsActive = true; // Le sort est actif le temps de sa durée d'utilisation.
            manaCost.Value = manaCost.Value - fire.spellManaCost; // Décrémentation du coût du sort du total de mana du joueur.
            if (fire.spellIsActive == true) // Déclanche les effet du sort si il est actif.
            {
                FireSpellEffect(); // Effets du sort.
                StartCoroutine(FireSpellCoroutine()); // Lance une coroutine qui limite les effets du sort dans le temps. 
            }
        }
    }
    private IEnumerator FireSpellCoroutine() // Permet de retourner à l'état normal après son délai. 
    {
        yield return new WaitForSeconds(fire.spellDuration); // Attend la fin de la durée du sort.
        m_Player.GetComponentInChildren<SkinnedMeshRenderer>().material = WizardMaterial; // Remet le joueur à sa couleur normale. 
        speedAcceleration.value = speedAcceleration.value * 0.8f; // Ralentit le joueur de sa valeur d'accélération pour retourner à la vitesse normale. 
        fire.spellIsActive = false; // Le sort est inactif.
        hit.hitValue = 1; // Les obstacles font des dégats normaux. 
        fire.spellEffectCount = 0; // Compteur pour gérer combien d'obstacles peuvent être touchés pendant le sort. Remis à 0 à la fin de la coroutine. 
        StartCoroutine(FireSpellCoolDownCoroutine()); // Lance le délai de récupération du sort. 
    }
    private IEnumerator FireSpellCoolDownCoroutine() // Coroutine pour gérer le temps de récupération du sort. 
    {
        fire.cooldownIsActive = true; // Bloque les lancements le temps de la coroutine. 
        yield return new WaitForSeconds(fire.spellCoolDowm); // Attend la fin du délai de récupération du sort. 
        fire.cooldownIsActive = false; // Le délai est terminé, le joueur peut lancer le sort si il a le mana nécessaire. 
    }
    private void FireSpellEffect() // Effets du sort. 
    {
        
        m_Player.GetComponentInChildren<SkinnedMeshRenderer>().material = FireEffectMaterial; // Change l'aspect du joueur pour montrer que le sort est actif.
        speedAcceleration.value = speedAcceleration.value * 1.2f; // Accélère légèrement le joueur. 
        hit.hitValue = 0; // Empêche le joueur de subir les dégats des obstacles. 
        fire.spellEffectCount = 1; // Compteur pour gérer combien d'obstacles peuvent être touchés pendant la durée du sort. 
        
    }
    public void OnCollisionEnter(Collision collision) // Gestion des collisions avec les obstacles.
    {
        if (fire.spellIsActive == true) // Si le sort est actuellement actif. 
        {
            if (collision.gameObject.CompareTag("Obstacle")) // Compare le tag pour s'assurer que le joueur touche un obstacle. 
            {
                Destroy(collision.gameObject); // Détruit l'obstacle touché.
                fire.spellEffectCount--; // Décrémente la valeur par objet touché. 
                if (fire.spellEffectCount == 0) // Si le joueur touche un obstacle avant la fin du sort. 
                {
                    StopCoroutine(FireSpellCoroutine()); // Arrête immédiatement le sort.
                    m_Player.GetComponentInChildren<SkinnedMeshRenderer>().material = WizardMaterial; // Remet le joueur à sa couleur normale.
                    speedAcceleration.value = speedAcceleration.value * 0.8f; // Ralentit le joueur de sa valeur d'accélération pour retourner à la vitesse normale. 
                    fire.spellIsActive = false; // Le sort est inactif.
                    hit.hitValue = 1; // Les obstacles font des dégats normaux. 
                    fire.spellEffectCount = 0;// Compteur pour gérer combien d'obstacles peuvent être touchés pendant le sort. Remis à 0 instantannément. 
                    StartCoroutine(FireSpellCoolDownCoroutine());// Coroutine pour gérer le temps de récupération du sort.

                }
            }
        }
        
    }
}
