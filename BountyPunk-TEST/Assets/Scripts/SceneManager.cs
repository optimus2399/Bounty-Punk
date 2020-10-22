using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
    public GameObject pauseMenu;


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnablePauseMenu();
        }
    }

    void EnablePauseMenu()
    {
        pauseMenu.SetActive(true);

    }

    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Bounty");
    }

}
