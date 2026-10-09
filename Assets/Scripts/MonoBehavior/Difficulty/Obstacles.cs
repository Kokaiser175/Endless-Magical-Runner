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
    public int invulnerabilityFrame;

    private void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(InvincibilityFrame());
            Debug.Log("hit");
            player_Health.Value = player_Health.Value - hit.hitValue;
        }
        
    }
    private IEnumerator InvincibilityFrame()
    {
        Debug.Log("CoroutineStart");
        yield return new WaitForSeconds(invulnerabilityFrame);
        Debug.Log("CoroutineEnd");
    }

}
