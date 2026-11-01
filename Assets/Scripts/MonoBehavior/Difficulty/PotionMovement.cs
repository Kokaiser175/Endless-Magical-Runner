using UnityEngine;

public class PotionMovement : MonoBehaviour
{
    [SerializeField] private RSO_AccelerationValue m_AccelerationValue;
    [SerializeField] private GameObject m_PotionMana;
    [SerializeField] private GameObject m_PotionHealth;

    private void Update()
    {
        PotionSpeed(); // On déplace les potions à la même vitesse que le chunk. 
    }
    private void PotionSpeed()
    {
        m_PotionHealth.transform.Translate(new Vector3(0, 0, -1f) * m_AccelerationValue.value * Time.deltaTime);
        m_PotionMana.transform.Translate(new Vector3(0, 0, -1f) * m_AccelerationValue.value * Time.deltaTime);

    }
}
