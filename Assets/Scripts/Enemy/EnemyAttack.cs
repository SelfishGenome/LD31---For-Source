using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    #region Fields 
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    
    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private bool playerInRange;
    private float timer;
    #endregion

    #region Awake
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Character");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    #endregion

    #region OnTriggerEnter
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    #endregion

    #region OnTriggerExit
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    #endregion

    #region Update
    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }
    }
    #endregion  

    #region Attack
    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
    #endregion
}
