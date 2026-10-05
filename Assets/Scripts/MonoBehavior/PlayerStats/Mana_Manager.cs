using System.Collections;
using UnityEngine;

public class Mana_Manager : MonoBehaviour
{
    [SerializeField] RSO_Mana m_mana;
 
    void Start()
    {
        m_mana.value = 0;
        StartCoroutine("ManaRegen");
    }

    private IEnumerator ManaRegen()
    {
        while (true)
        {
            if (m_mana.value <= 100)
            {
                yield return new WaitForSeconds(1);
                m_mana.value += 2;
                Debug.Log($"{m_mana.value.ToString()}");

            }
            if( m_mana.value > 98)
            {  break;}
        }      
    }
}
