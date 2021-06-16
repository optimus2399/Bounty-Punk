using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{

   [SerializeField] GameObject load1;
   [SerializeField] GameObject load2;
    [SerializeField] GameObject load3;
    [SerializeField] GameObject load4;
    [SerializeField] GameObject load5;
    [SerializeField] GameObject load6;
    public float textDelay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Load1();
       
    }

     public void Load1()
    {
        load1.SetActive(true);
        Invoke("Load2", textDelay);
    }

    public void Load2()
    {
        load1.SetActive(false);
        load2.SetActive(true);
        Invoke("Load3", textDelay);
    }

    public void Load3()
    {
        load2.SetActive(false);
        load3.SetActive(true);
    }

    public void Load4()
    {
        load3.SetActive(false);
        load4.SetActive(true);
    }

    public void Load5()
    {
        load4.SetActive(false);
        load5.SetActive(true);
    }

    public void Load6()
    {
        load5.SetActive(false);
        load6.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
     
        
    }

    
}
