using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SSO_PlayerMovements corridor_Position;
    [SerializeField] private RSO_PlayerRuntime player_Runtime;
    [SerializeField] private GameObject m_player;
    [SerializeField] private InputActionReference switchCorridor;

    private int currentCorridor; // -1 = left; 0 = middle ; 1 = right.
    private Vector3 targetCorridor;

    
    void Start()
    {
        corridor_Position.rightCorridor = new Vector2(4, player_Runtime.grounded); // Initialisation des vecteurs des couloirs, la valeur de hauteur est gérée dans le RSO_PlayerRuntime car peut changer.
        corridor_Position.leftCorridor = new Vector2(-4, player_Runtime.grounded);
        corridor_Position.middleCorridor = new Vector2(0, player_Runtime.grounded);

        m_player.transform.position = corridor_Position.middleCorridor; // position de départ
    }

        private void OnEnable()
        {
            switchCorridor.action.Enable();
            switchCorridor.action.performed += SwitchLane;
        }
        
        private void OnDisable()
        {
            switchCorridor.action.performed -= SwitchLane;
            switchCorridor.action.Disable();
        }

    private void Update()
    {
        m_player.transform.position = Vector3.MoveTowards(m_player.transform.position, targetCorridor, corridor_Position.switchBetweenLaneSpeed); // transition fluide entre les couloirs appelé par l'input choisit
    }

    public void SwitchLane(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<Vector2>().x; // Lecture de la valeur X de l'input uniquement
        
        if (input < 0)
        {
            currentCorridor--;
            if (currentCorridor < -1) {currentCorridor = -1;}
        }
        if (input > 0)
        {
            currentCorridor++;
            if (currentCorridor > 1) { currentCorridor = 1;} // On verouille la valeur pour ne pas dépasser -1 ou 1.
        }
        if (currentCorridor == -1)
        {
            targetCorridor = corridor_Position.leftCorridor;  // déplacement sur le couloir avec la valeur de l'int currentCorridor + temps de transition pour changer de couloir (0.3f)
            
        }
        if (currentCorridor == 0)
        {
            targetCorridor = corridor_Position.middleCorridor;
             
        }
        if (currentCorridor == 1)
        {
            targetCorridor = corridor_Position.rightCorridor;
            
        }
    }

}
