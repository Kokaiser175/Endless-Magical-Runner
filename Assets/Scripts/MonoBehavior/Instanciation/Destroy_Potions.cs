using System;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy_Potions : MonoBehaviour
{
    [SerializeField] GameObject Health_Potion;
    [SerializeField] GameObject Mana_Potion;
    private void OnCollisionEnter(Collision collision) // A la collision on détruit la potion passé par le joueur.
    {
        Destroy(Health_Potion);  
        Destroy(Mana_Potion);
    }
}
