using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpManager : MonoBehaviour
{
    private int healAmount = 20;
    private float rotationSpeed = 0.6f;
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMove;
    private GameObject mainCam;
    private GameManager gameManager; 

    #region Awake
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMove = player.GetComponent<PlayerMovement>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        gameManager = mainCam.GetComponent<GameManager>();
    }
    #endregion

    #region Update
    void Update()
    {
        transform.Rotate(Random.Range(0, 360) * Time.deltaTime * rotationSpeed,
            transform.rotation.y,
            transform.rotation.z);
    }
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Character")
        {
            switch (name)
            {
                case "PickUpHealth(Clone)":
                    playerHealth.GetHealth(healAmount);
                    gameManager.PlaySound(3);
                    Destroy(gameObject);
                    break;
                case "PickUpDuelWeap(Clone)":
                    playerHealth.ActivateGun();
                    gameManager.PlaySound(0);
                    Destroy(gameObject);
                    break;
                case "PickUpSpeed(Clone)":
                    playerMove.moveSpeed = 12;
                    gameManager.PlaySound(1);
                    Destroy(gameObject);
                    break;
                case "PickUpPower(Clone)":
                    playerHealth.IncreasePower();
                    gameManager.PlaySound(2);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}