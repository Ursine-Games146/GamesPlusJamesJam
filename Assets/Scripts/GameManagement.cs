using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public float punchBackForce;
    public float enemyHP;
    public float citizenHP;
    private float P;
    private bool won = false;
    private bool Boss = false;
    public int enemyCount;
    public int enemyKilled;
    public Transform spawn;
    public GameObject goblinPF;
    public GameObject Menu;
    public GameObject Enemy;
    public GameObject winText;
    public Enemy enemy;



    private void Update()
    {
        P = Random.Range(-3.0f, 3.0f);
        if(Enemy != null)
        {
            enemyHP = enemy.enemyHP;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }

        if(enemyKilled >= 6 && !Boss)
        {
            Boss = true;
            Enemy.SetActive(true);
        }

        if(enemyHP <= 0 && !won)
        {
            won = true;
            winText.SetActive(true);
        }
    }


    public void SpawnEnemy()
    {
        Instantiate(goblinPF, new Vector3(spawn.position.x + P, spawn.position.y, spawn.position.z + P), Quaternion.identity);
        Instantiate(goblinPF, new Vector3(spawn.position.x - P, spawn.position.y, spawn.position.z - P), Quaternion.identity);
        enemyCount += 2;
    }

    public void PauseGame()
    {
        
    }


    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        bl_SceneLoaderUtils.GetLoader.LoadLevel("Test");
    }

    public void QuitGame()
    {
        Debug.Log("Quit the Game");
        Application.Quit();
    }

    public void CloseWinText()
    {
        winText.SetActive(false);
    }
}

