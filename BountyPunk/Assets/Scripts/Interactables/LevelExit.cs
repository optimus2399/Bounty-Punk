using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject InteractableUI;
    bool inRange = false;
    string level;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        InteractableUI.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        InteractableUI.SetActive(false);
    }
    
    public void SetLevel(string sceneToSelect)
    {
        level = sceneToSelect;
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
            SceneManager.LoadScene(level);
        }

        if (this.gameObject.tag == "House")
        {
            Exit();
        }
    }
}
