using UnityEngine;
using UnityEngine.Rendering;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] RSO_Health m_Health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Health.Value++;
            Destroy(gameObject);
        }
    }

}
