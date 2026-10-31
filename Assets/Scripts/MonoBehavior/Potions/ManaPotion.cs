using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] RSO_Mana m_Mana;
    public int m_ManaPotionValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Mana.Value = m_Mana.Value + m_ManaPotionValue;
            Destroy(gameObject);
        }
    }
}
