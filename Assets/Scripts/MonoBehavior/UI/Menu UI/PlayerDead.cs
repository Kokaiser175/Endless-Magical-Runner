using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] RSO_Health health;
   public void PlayerisDead()
    {
        if (health.Value <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single); // Charge le GameOver
        }
        
    }
}
