using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Loader loader;
    bool inRange = false;
    public PC pc;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
    private void Start()
    {
        GameObject level = GameObject.Find("level");
        pc = level.GetComponent<PC>();
    }

    private void Update()
    {
        if (inRange)
        {
            Exit();
        }
    }

    public void Exit()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("yes@!");
            if ( pc.level == 0 )
            {
                Debug.Log("exit"); 
                SceneManager.LoadScene("BountyOne");
            }
        }
    }
}
