using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField] RSO_Score value;
    [SerializeField] RSO_AccelerationValue speed;

    private void Update()
    {
        value.value++;
    }





}
