using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public float punchBackForce;
    public float enemyHP;
    public float citizenHP;
    private float P;
    public Transform spawn;
    public GameObject goblinPF;
    public GameObject Menu;



    private void Update()
    {
        P = Random.Range(-5.0f, 5.0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void SpawnEnemy()
    {
        Instantiate(goblinPF, new Vector3(spawn.position.x + P, spawn.position.y, spawn.position.z + P), Quaternion.identity);
        Instantiate(goblinPF, new Vector3(spawn.position.x - P, spawn.position.y, spawn.position.z - P), Quaternion.identity);
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
}

