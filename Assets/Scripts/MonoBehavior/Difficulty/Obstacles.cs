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
    public bool hasBeenEat;

    private void Start()
    {
        hit.hitValue = 1;
        hasBeenEat = false;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
               if (hasBeenEat == false)
                {
                Debug.Log("hit");
                StartCoroutine(InvincibilityFrame());
                }
            else { return; }
        }
        
    }
    private IEnumerator InvincibilityFrame()
    {
        Debug.Log("CoroutineStart");
        GetHit();
        hasBeenEat = true;
        yield return new WaitForSeconds(invulnerabilityFrame);
        hasBeenEat = false;
        Debug.Log("CoroutineEnd");
    }
    private void GetHit()
    {
        player_Health.Value = player_Health.Value - hit.hitValue;
    }

}
