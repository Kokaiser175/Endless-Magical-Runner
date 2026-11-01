using UnityEngine;
using UnityEngine.Rendering;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] RSO_Health m_Health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Health.Value++; // On ajoute 1 point de vie à la collision.
            Destroy(gameObject); // On détruit la potion. 
        }
    }

}
