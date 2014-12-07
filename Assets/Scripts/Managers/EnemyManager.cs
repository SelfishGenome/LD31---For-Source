using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    #region Fields
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public List<GameObject> boss;
    public float spawnTime;
    public Transform[] spawnPoints;
    public static int enemiesRemaining;
    public int levelTarget;
    public GameObject levelCompleteText;
    public GameObject bossApproachesText;
    public GameObject remainingEnemiesText;
    
    public GameOverManager gameOverManager;

    private int currentLevelTarget;
    [HideInInspector]
    public int bossNumber = 0;
    #endregion

    #region Start
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
        enemiesRemaining = levelTarget;
    }
    #endregion

    #region Spawn
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if(currentLevelTarget < levelTarget)
        {
            int enemyIndex = Random.Range(0, enemy.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            currentLevelTarget++;
        }
    }
    #endregion

    #region ChangeLevel
    public void ChangeLevel()
    {
        StartCoroutine("IChangeLevel");
    }
    #endregion

    #region IChangeLevel
    IEnumerator IChangeLevel()
    {        
        levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(2);
        remainingEnemiesText.SetActive(true);
        levelCompleteText.SetActive(false);
        levelTarget += 50;
        enemiesRemaining = levelTarget;
        currentLevelTarget = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    #endregion

    #region ChangeLevel
    public void SpawnBoss()
    {
        StartCoroutine("ISpawnBoss");
    }
    #endregion

    #region IChangeLevel
    IEnumerator ISpawnBoss()
    {
        bossApproachesText.SetActive(true);
        yield return new WaitForSeconds(2);
        bossApproachesText.SetActive(false);

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(boss[bossNumber], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        currentLevelTarget++;

        bossNumber++;
    }
    #endregion

    public int GetBoss()
    {
        int currentBoss = bossNumber;
        Debug.Log(currentBoss);
        return currentBoss;
    }

    public void GameOver()
    {
        gameOverManager.lost = true;
    }

    public void LevelComplete()
    {
        gameOverManager.levelComplete = true;
    }
}
