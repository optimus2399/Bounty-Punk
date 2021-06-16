using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     int enemyDeathCount=0;
    [SerializeField] GameObject[] barriers;
    [SerializeField] int[] totalEnemyCount;
    Buttons buttons;
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

    public void EnemyDie()
    {
        enemyDeathCount++;
    }
}
