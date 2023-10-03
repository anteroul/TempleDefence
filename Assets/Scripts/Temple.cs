using UnityEngine;

public class Temple : GameManager
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
        if (health >= 0)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }
}
