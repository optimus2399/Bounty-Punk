using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject car;
    [SerializeField] GameObject bountyUI;
    public int level = 0;
    bool inRange = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;  
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Load5()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            car.SetActive(true);
            Time.timeScale = 0;
            bountyUI.SetActive(true);
            loader.Load5();
            
            
        }
    }

    public void ExitUi()
    {
        Time.timeScale = 1;
        bountyUI.SetActive(false);

    }

    private void Update()
    {
        if (inRange)
        {
            Load5();
        }
    }

    public void LoadBountyOne()
    {
        level = 0;
        Debug.Log("1");
    }

    public int GetLevel()
    {
        return level;
    }
}

