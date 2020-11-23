using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    
    GameObject load1;
    GameObject load2;
    GameObject load3;
    
    // Start is called before the first frame update
    void Start()
    {
        
        load1 = GameObject.FindGameObjectWithTag("Load1");
        load2 = GameObject.FindGameObjectWithTag("Load2");
       // load3 = GameObject.FindGameObjectWithTag("Load3");

        load1.SetActive(false);
        load2.SetActive(false);
        //load3.SetActive(false);
      

    }

  

    // Update is called once per frame
    void Update()
    {
        load1.SetActive(true);
        
        
            
            Destroy(load1,4);
            if (load1 == null)
            {
                load2.SetActive(true);
            Destroy(load2, 4);
            }
        
        if (load2 == null)
        {
           // load3.SetActive(true);
           // Destroy(load3, 4);
        }
        
       
            
         
            
            
        
        
    }

    
}
