using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    #region Fields 
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    [HideInInspector]
    public bool lost = false;
    public bool levelComplete = false;
    public GameObject lostText;
    public GameObject wonText;
    public GameObject enemiesRemaining;
    public GameObject levelOver;
    public EnemyManager enemyManager;


    private float restartTimer = 0;
    #endregion

    #region Update
    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            if(lostText.activeSelf == false)
            {
                restartTimer = 0;
                lostText.SetActive(true);
            }
            if (enemiesRemaining.activeSelf == true)
            {
                enemiesRemaining.SetActive(false);
            }
            
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(0);
            }
            
        }

        if (lost == true)
        {
            
            if(wonText.activeSelf == false)
            {
                restartTimer = 0;
                wonText.SetActive(true);
            }
            if (enemiesRemaining.activeSelf == true)
            {
                enemiesRemaining.SetActive(false);
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(0);
            }
        }

        if (levelComplete == true)
        {
            
            if (levelOver.activeSelf == false)
            {
                levelOver.SetActive(true);
            }
            if (enemiesRemaining.activeSelf == true)
            {
                enemiesRemaining.SetActive(false);
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                
                enemyManager.ChangeLevel();
                levelComplete = false;
            }
        }
    }
    #endregion 
}
