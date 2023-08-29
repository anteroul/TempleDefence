using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] pathPoints;
    public Healthbar healthbar;
    public GameObject blood;
    public float moveSpeed;
    public int damage;
    
    Temple temple;
    bool alive;
    const int maxHealth = 100;
    int health;
    int destinationReached;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        healthbar.SetMaxHealth(maxHealth);
        health = maxHealth;
        destinationReached = 0;
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (health > 0)
            {
                if (destinationReached < pathPoints.Length)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pathPoints[destinationReached].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, pathPoints[destinationReached].position) < 0.2f)
                    {
                        destinationReached++;
                    }
                }
                else
                {
                    temple.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
            else if (health <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                healthbar.gameObject.SetActive(false);
                Instantiate(blood, transform);
                alive = false;
            }
            healthbar.SetHealth(health);
        } else {
            Destroy(gameObject, 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= other.gameObject.GetComponent<ProjectileScript>().damage;
            Destroy(other.gameObject);
        }
    }
}
