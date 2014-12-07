using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagerSurvival : MonoBehaviour
{
    #region Fields
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public GameObject[] boss;
    public float spawnTime;
    public float bossSpawnTime;
    public Transform[] spawnPoints;
    
    public GameOverManager gameOverManager;

    private int currentLevelTarget;
    [HideInInspector]
    public int bossNumber = 0;
    #endregion

    #region Start
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("SpawnBoss", bossSpawnTime, bossSpawnTime);
    }
    #endregion

    #region Spawn
    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int enemyIndex = Random.Range(0, enemy.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    #endregion

    void SpawnBoss()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int bossIndex = Random.Range(0, boss.Length);
        int bossPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(boss[bossIndex], spawnPoints[bossPointIndex].position, spawnPoints[bossPointIndex].rotation);
    }

    public void GameOver()
    {
        gameOverManager.lost = true;
    }
}
