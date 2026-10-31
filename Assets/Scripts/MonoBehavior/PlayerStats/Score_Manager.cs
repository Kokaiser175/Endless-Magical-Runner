using System.Collections;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField] RSO_Score m_Value;
    [SerializeField] RSO_AccelerationValue speed;

    private void Start()
    {
        m_Value.Value = 0;
        StartCoroutine(ScoreUp());
    }

    private IEnumerator ScoreUp()
    {
        while (true)
        {
            int Multiplicator = ((int)speed.value);
                yield return new WaitForSeconds(1);
                m_Value.Value += 10 * Multiplicator;
        }
    }
}
