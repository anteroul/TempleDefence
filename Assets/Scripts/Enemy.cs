using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;
    public Healthbar healthbar;
    public GameObject prefab;
    public GameObject blood;
    public float moveSpeed;
    public int level;
    public Transform[] pathPoints;
    SpriteRenderer ren;
    Temple temple;
    EnemyBehaviour prefabScript;
    bool alive;
    int damage;
    int maxHealth;
    int health;
    int destinationReached;

    void Awake()
    {
        ren = gameObject.GetComponent<SpriteRenderer>();
        ren.sprite = sprites[(int)level];
        Instantiate(prefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        healthbar.SetMaxHealth(maxHealth);
        health = maxHealth;
        damage = 20 * level;
        maxHealth = 1000 * level;
        destinationReached = 0;
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
        prefabScript = prefab.GetComponent<EnemyBehaviour>();
        
        if (!prefabScript.IsAlive())
        {
            prefabScript.health = health;
            prefabScript.GetRenderer().sprite = ren.sprite;
            prefabScript.alive = alive;
        }
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
                    float angle = Mathf.Atan2(pathPoints[destinationReached].position.y, pathPoints[destinationReached].position.x) * Mathf.Rad2Deg;
                    prefab.transform.rotation = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward);
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
                prefab.GetComponent<SpriteRenderer>().enabled = false;
                healthbar.gameObject.SetActive(false);
                Instantiate(blood, transform);
                alive = false;
            }
            healthbar.SetHealth(health);
        }
        else
        {
            Destroy(gameObject, 0.75f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= other.gameObject.GetComponent<ProjectileScript>().damage;
            Destroy(other.gameObject);
        }
        prefabScript.health = health;
    }

    public bool IsAlive()
    {
        return alive;
    }
}
