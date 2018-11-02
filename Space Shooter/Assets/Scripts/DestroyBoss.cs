using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBoss : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    public float StartingHealth = 10f;               // The amount of health each tank starts with.
    public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.

    private float CurrentHealth;                      // How much health the tank currently has.
    private bool Dead;                                // Has the tank been reduced beyond zero health yet?

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        CurrentHealth = StartingHealth;
        Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, CurrentHealth / StartingHealth);
    }

    public void TakeDamage()
    {
        CurrentHealth--;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (CurrentHealth <= 0f && !Dead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        Dead = true;

        // Turn the boss off.
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);
        Destroy(gameObject);
        gameController.deadBoss = true;
    }

    void OnTriggerEnter(Collider other)
    {
        TakeDamage();
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
