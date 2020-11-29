using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Loader loader;
    public int currentLevel;
     
    bool inRange = false;
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
        currentLevel = GetComponent<PC>().GetLevel();
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
            if ( currentLevel == 1)
            {
                SceneManager.LoadScene("BountyOne");
            }
        }
    }
}
