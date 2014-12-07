using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Fields
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public AudioSource deathClip;
    public ParticleSystem[] enemyPS;
    public BoxCollider boxCollider;
    public int enemiesRemaining;
    public GameObject[] drops;

    private GameObject eManager;
    private EnemyManager enemyManager;
    private MeshRenderer meshRenderer; 
    private AudioSource enemyAudio;
    private ParticleSystem deathParticles;
    private bool isDead;
    private float dropRate = 5f;


    #endregion

    #region Awake
    void Awake ()
    {
        enemyAudio = GetComponent <AudioSource> ();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        currentHealth = startingHealth;
        eManager = GameObject.Find("EnemyManager");
        enemyManager = (EnemyManager)eManager.GetComponent(typeof(EnemyManager));
    }
    #endregion

    #region TakeDamage
    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        //enemyAudio.Play ();

        currentHealth -= amount;

        enemyPS[0].transform.position = hitPoint;
        enemyPS[0].Play();

        if(currentHealth <= 0)
        {
            meshRenderer.enabled = false;
            boxCollider.isTrigger = true;
            
            Death ();
        }
    }
    #endregion

    #region Death
    void Death ()
    {
        isDead = true;
        float dropVal = Random.Range(0, 100);
        if (dropVal <= dropRate)
        {
            int randDrop = Random.Range(0, drops.Length);
            Instantiate(drops[randDrop], gameObject.transform.position, Quaternion.identity);
        }

        enemyPS[1].Play();

        enemyAudio.Play ();

        ScoreManager.score += scoreValue;

        if(gameObject.tag != "Boss")
        {
            EnemyManager.enemiesRemaining--;
            if(EnemyManager.enemiesRemaining == 0)
            {
                enemyManager.SpawnBoss();
            }
        }
        
        if(Application.loadedLevel == 1)
        {
            if (gameObject.tag == "Boss")
            {
                if (enemyManager.bossNumber >= enemyManager.boss.Count)
                {
                    enemyManager.GameOver();
                    return;
                }
                else if (enemyManager.bossNumber < enemyManager.boss.Count)
                {
                    enemyManager.LevelComplete();
                    Destroy(gameObject, 2f);
                    return;
                }
            }        
        }
        

        Destroy(gameObject, 2f);
    }
    #endregion
}
