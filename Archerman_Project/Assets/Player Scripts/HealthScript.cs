using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    private int startingHealth = 100;
    private int currentHealth;
    private bool isDead;
    private int startingNumLives = 3;
    private int currentNumLives;

    public GameObject healthSlider;
    private UnityEngine.UI.Slider health;

    // Use this for initialization
    void Awake()
    {
        health = healthSlider.GetComponentInChildren<UnityEngine.UI.Slider>();
        currentHealth = startingHealth;
        currentNumLives = startingNumLives;
    }

    // Update is called once per frame
    void Update()
    {
        health.value = currentHealth;
    }

    public int StartingHealth
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    public int CurrentNumLives
    {
        get { return currentNumLives; }
        set { currentNumLives = value; }
    }

    /// <summary>
    /// Inflicts damage to the players health
    /// </summary>
    /// <param name="amount"></param> Amount of damage, by enemy.
    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    /// <summary>
    /// Kills the player.
    /// </summary>
    void Death()
    {
        isDead = true;
        currentNumLives -= 1;
    }
}
