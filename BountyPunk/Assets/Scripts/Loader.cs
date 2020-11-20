using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] GameObject Player;
    GameObject load1;
    GameObject load2;
    GameObject load3;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = Player.transform.position;
        load1 = GameObject.FindGameObjectWithTag("Load1");
        load2 = GameObject.FindGameObjectWithTag("Load2");
       // load3 = GameObject.FindGameObjectWithTag("Load3");
        load2.SetActive(false);
       // load3.SetActive(false);

    }

  

    // Update is called once per frame
    void Update()
    {
        
        if (Player.transform.position != currentPos)
        {
            Destroy(load1);
            load2.SetActive(true);
            Destroy(load2, 2);
            
            
        }
    }

    
}
