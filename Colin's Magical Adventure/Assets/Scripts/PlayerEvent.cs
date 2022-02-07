using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int DamagePerCollision;

    private bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
        if(currentHealth == 0)
        {
            PlayerPrefs.SetInt("IsDead", 1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;
        if (other.gameObject.tag == "Ennemy")
        {
            if(PlayerPrefs.GetInt("Victory") == 0)
                TakeDamage(20);
        }
    }
}
