using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     int enemyDeathCount=0;
    [SerializeField] GameObject[] barriers;
    [SerializeField] int[] totalEnemyCount;
    Buttons buttons;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverCanvas;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        buttons = GetComponent<Buttons>();
    }

  
    void Update()
    {
        if (boss == null)
        {
            StartCoroutine(LevelComplete());
        }

        if (player == null)
        {
            StartCoroutine(GameOver());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttons.PauseButton();
        }

        for(int i = 0; i < barriers.Length; i++)
        {
            if (enemyDeathCount == totalEnemyCount[i])
            {
                Destroy(barriers[i].gameObject);
            }  
        }
    }

    IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(4);
        levelCompleteCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(4);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void EnemyDie()
    {
        enemyDeathCount++;
    }
}
