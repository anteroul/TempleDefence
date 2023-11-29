using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;
    public Transform[] pathPoints;
    public Healthbar healthbar;
    public GameObject blood;
    public float moveSpeed;
    public int level;
    SpriteRenderer ren;
    Temple temple;
    bool alive;
    int damage;
    int maxHealth;
    int health;
    int destinationReached;

    void Awake()
    {
        damage = 20 * level;
        maxHealth = 1000 * level;
        ren = GetComponent<SpriteRenderer>();
        ren.sprite = sprites[(int)level];
    }

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
                    transform.position = UnityEngine.Vector2.MoveTowards(transform.position, pathPoints[destinationReached].position, moveSpeed * Time.deltaTime);
                    float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
                    if (angle < 90 || angle < -90)
                    {
                        transform.rotation = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward);
                    }
                    if (UnityEngine.Vector2.Distance(transform.position, pathPoints[destinationReached].position) < 0.2f)
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
        }
        else
        {
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

    public bool IsAlive()
    {
        return alive;
    }
}
