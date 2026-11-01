using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Transform leftAnchor;
    [SerializeField] Transform middleAnchor;
    [SerializeField] Transform rightAnchor;
    [SerializeField] Transform heightAnchor;
    [SerializeField] GameObject m_Player;
    [SerializeField] InputActionReference switchLane;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference slide;
    public Vector3 playerCurrentPosition;
    private Vector3 targetLane;
    private Vector3 targetJump;
    private int currentCorridor; // -1 = left; 0 = middle ; 1 = right.
    public float grounded;
    public float jumpDuration;
    public float slideDuration;
    public float jumpSpeed;
    public float switchingLaneSpeed;
    private bool isJumping;
    private bool isSliding;

    private void Start()
    {
        transform.position = middleAnchor.transform.position;
        isJumping = false;
        isSliding = false;
    }

    private void OnEnable() // Abonnement / Désabonnement pour les inputs
    {
        switchLane.action.Enable();
        switchLane.action.performed += SwitchingLane;
        jump.action.Enable();
        jump.action.performed += Jumping;
        slide.action.Enable();
        slide.action.performed += Sliding;
    }
    private void OnDisable()
    {

        switchLane.action.performed -= SwitchingLane;
        switchLane.action.Disable();
        jump.action.performed -= Jumping;
        jump.action.Disable();
        slide.action.performed -= Sliding;
        slide.action.Disable();
    }
    private void Update()
    {
        playerCurrentPosition.x = Mathf.Lerp(playerCurrentPosition.x, targetLane.x, (switchingLaneSpeed * Time.deltaTime)); // On déplace le joueur vers le couloir ciblé.
        transform.position = playerCurrentPosition;

        if (isJumping == true) // Si le booléen qui gère le saut est vrai, on déplace le joueur vers l'ancre en hauteur. 
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, targetJump.y, (jumpSpeed * Time.deltaTime));
        }
        if (isJumping == false)// Si le booléen qui gère le saut est faux, on déplace le joueur vers l'ancre au sol. 
        {
            playerCurrentPosition.y = Mathf.Lerp(playerCurrentPosition.y, grounded, (jumpSpeed * Time.deltaTime));
        }
    }

    private void SwitchingLane(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<Vector2>().x; // Lecture de la valeur X de l'input uniquement

        if (input < 0)
        {
            currentCorridor--;
            if (currentCorridor < -1) { currentCorridor = -1; }
        }
        if (input > 0)
        {
            currentCorridor++;
            if (currentCorridor > 1) { currentCorridor = 1; } // On verouille la valeur pour ne pas dépasser -1 ou 1.
        }
        if (currentCorridor == -1)
        {
            targetLane.x = leftAnchor.transform.position.x;  // Déplacement sur le couloir avec la valeur de l'int currentCorridor

        }
        if (currentCorridor == 0)
        {
            targetLane.x = middleAnchor.transform.position.x;

        }
        if (currentCorridor == 1)
        {
            targetLane.x = rightAnchor.transform.position.x;

        }
    }
    private void Jumping(InputAction.CallbackContext context) // Fonction du saut
    {
        if (isSliding == true) { return; } // Si on glisse pas de saut
        if (isJumping == true) { return; } // Si on jump pas de saut pendant le jump
        if (m_Player.transform.position.y <= 0.5f) // Si on est à 0.5f de haut. 
        {
            isJumping = true; // Lors du saut le booléen passe à vrai pour la durée du saut.
            targetJump.y = heightAnchor.transform.position.y; // Le point cible prend les coordonées de l'ancre haute. 
            StartCoroutine(EndJump()); // On lance la coroutine ajuster la longueur du saut. 
        }
        else return;
           
    }
    private IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpDuration); // On attend la fin de la durée du saut. 
        isJumping = false; // Le saut est terminé on peut resauter. 
    }
    private void Sliding(InputAction.CallbackContext context) // Fonction de la glissade.
    {
        if (isJumping == true) { return; } // Si on saute pas de glissade
        if (isSliding == true) { return; } // Si on glisse, pas de glissade pendant la glissade.
            isSliding = true; // Lors de la glissade le booléen passe à vrai pour la durée de la glissade.
       StartCoroutine(EndSlide()); // On lance la coroutine qui gère la glissade. 
       
    }
    private IEnumerator EndSlide()
    {
        m_Player.transform.rotation = new Quaternion(-90f, 0, 0, 90); // Le joueur pivote.
        yield return new WaitForSeconds(slideDuration); // On attend la fin de la durée de la glissade
        m_Player.transform.rotation = Quaternion.identity; // On remet le joueur dans sa position d'origine.
        isSliding = false; // On peut de nouveau glisser. 
    }
}
