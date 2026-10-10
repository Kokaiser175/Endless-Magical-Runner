using System;
using System.Collections;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] RSO_ObstacleValues hit;
    [SerializeField] RSO_Health player_Health;
    [SerializeField] GameObject m_Player;
    public float invulnerabilityFrame;

    private void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hit");
            player_Health.Value = player_Health.Value - hit.hitValue;
            StartCoroutine(InvincibilityFrame());
        }
        
    }
    private IEnumerator InvincibilityFrame()
    {
        Debug.Log("CoroutineStart");
        m_Player.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(invulnerabilityFrame);
        m_Player.GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("CoroutineEnd");
    }

}
