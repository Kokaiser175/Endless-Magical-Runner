using System.Collections;
using UnityEngine;

public class Mana_Manager : MonoBehaviour
{
    [SerializeField] RSO_Mana m_mana;
 
    void Start()
    {
        m_mana.Value = 0;
        StartCoroutine("ManaRegen");
    }

    private IEnumerator ManaRegen()
    {
        while (true)
        {
            if (m_mana.Value <= 100)
            {
                yield return new WaitForSeconds(1);
                m_mana.Value += 2; ;
            }
            if (m_mana.Value > 98)
            { m_mana.Value += 0; }
            if (m_mana.Value > 100)
            {
                m_mana.Value = 100;
            }
        }
    }
}
