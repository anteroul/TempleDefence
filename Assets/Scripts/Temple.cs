using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{
    const int maxHealth = 100;
    int health;
    
    public Healthbar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
