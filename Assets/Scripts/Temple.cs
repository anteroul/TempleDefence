using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{
    const float maxHealth = 100;
    public float health;
    
    public Healthbar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth((int)maxHealth);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth((int)health);
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }
}
