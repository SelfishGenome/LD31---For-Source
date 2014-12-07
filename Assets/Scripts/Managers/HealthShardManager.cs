using UnityEngine;
using System.Collections;

public class HealthShardManager : MonoBehaviour
{
    private int healAmount = 20;
    private float rotationSpeed = 0.6f;
    private GameObject player;
    private PlayerHealth playerHealth;

    #region Awake
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    #endregion

    #region Update
    void Update()
    {
        transform.Rotate(Random.Range(0, 360) * Time.deltaTime * rotationSpeed,
            Random.Range(0, 360) * Time.deltaTime * rotationSpeed,
            Random.Range(0, 360) * Time.deltaTime * rotationSpeed);
    }
    #endregion

    void OnTriggerEnter(Collider col)
    { 
        if(col.tag == "Character")
        {
            playerHealth.GetHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
