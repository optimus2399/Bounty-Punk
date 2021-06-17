using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] int bossDamage;
    bool isPillar1 = false;
    bool isPillar2 = false;
    bool isPillar3 = false;
    bool isPillar4 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
        if (this.gameObject.transform.childCount == 3)
        {
            if (!isPillar1)
            {
                boss.GetComponent<HealthSystem>().DealDamage(bossDamage);
                isPillar1 = true;
            }  
        }

        if (this.gameObject.transform.childCount == 2)
        {
            if (!isPillar2)
            {
                boss.GetComponent<HealthSystem>().DealDamage(bossDamage);
                isPillar2 = true;
            }
        }

        if (this.gameObject.transform.childCount == 1)
        {
            if (!isPillar3)
            {
                boss.GetComponent<HealthSystem>().DealDamage(bossDamage);
                isPillar3 = true;
            }
        }

        if (this.gameObject.transform.childCount == 0)
        {
            if (!isPillar4)
            {
                boss.GetComponent<HealthSystem>().DealDamage(bossDamage);
                isPillar4 = true;
            }
        }
    }
}
