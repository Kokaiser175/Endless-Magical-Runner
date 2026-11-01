using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] RSO_Mana m_Mana;
    public int m_ManaPotionValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Mana.Value = m_Mana.Value + m_ManaPotionValue; // Lors d'une collision, on ajoute la valeur sérialisé à la réserve de mana. 
            Destroy(gameObject); // On détruit la potion. 
        }
    }
}
