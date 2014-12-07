using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    #region Fields
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public Image healedImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color healFlashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color damageFlashColour = new Color(1f, 0f, 0f, 0.1f);
    public PlayerShooting gun;
    public PlayerShooting gun2;
    public ParticleSystem deathParticles;

    private float renderWidth = .1f;
    private AudioSource playerAudio;
    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;
    private bool isDead;
    private bool damaged;
    private bool healed;
    private LineRenderer lRender1;
    private LineRenderer lRender2;
    #endregion

    #region Awake
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
        lRender1 = gun.GetComponent<LineRenderer>();
        lRender2 = gun2.GetComponent<LineRenderer>();
    }
    #endregion

    #region Update
    void Update()
    {
        if (damaged)
        {
            damageImage.color = damageFlashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (healed)
        {
            healedImage.color = healFlashColour;
        }
        else
        {
            healedImage.color = Color.Lerp(healedImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        healed = false;
    }
    #endregion

    #region TakeDamage
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    #endregion

    #region GetHealth
    public void GetHealth(int amount)
    {
        healed = true;

        currentHealth += amount;

        healthSlider.value = currentHealth;

        if (currentHealth >= 100)
        {
            currentHealth = 100;
            healthSlider.value = currentHealth;
        }
    }
    #endregion

    #region Death
    void Death()
    {
        isDead = true;

        gameObject.renderer.enabled = false;
        gun.renderer.enabled = false;
        gun2.renderer.enabled = false;

        deathParticles.Play();
        playerShooting.DisableEffects();

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
    #endregion

    public void ActivateGun()
    {
        gun2.gameObject.SetActive(true);
    }

    public void IncreasePower()
    {
        gun.damagePerShot += 20;
        gun2.damagePerShot += 20;

        gun.range += 20;
        gun2.range += 20;

        renderWidth += .2f;

        lRender1.SetWidth(renderWidth, renderWidth);
        lRender2.SetWidth(renderWidth, renderWidth);
    }
}
