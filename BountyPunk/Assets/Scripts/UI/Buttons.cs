using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    bool isPause=true ;
  

    public void PlayButton()
    {
        SceneManager.LoadScene("House");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HouseButton()
    {
        SceneManager.LoadScene("House 1");
    }

    public void PauseButton()
    {
        if (isPause)
        {
            Time.timeScale = 0;
            isPause = false;
            if (PauseScreen == null)
            {
                return;
            }
            else
            {
                PauseScreen.SetActive(true);
            }
            
        }
        else
        {
            Time.timeScale = 1;
            isPause = true;
            if (PauseScreen == null)
            {
                return;
            }
            else
            {
                PauseScreen.SetActive(false);
            }
           
        }
    }
}
