using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    #region Fields
    private Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private NavMeshAgent nav;
    #endregion

    #region Awake
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<NavMeshAgent>();
    }
    #endregion

    #region Update
    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
    #endregion
}
