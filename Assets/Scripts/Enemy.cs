using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] pathPoints;
    public float moveSpeed;
    public int damage;
    
    Temple temple;
    int destinationReached;

    // Start is called before the first frame update
    void Start()
    {
        destinationReached = 0;
        temple = GameObject.FindGameObjectWithTag("Temple").GetComponent<Temple>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationReached < pathPoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, pathPoints[destinationReached].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pathPoints[destinationReached].position) < 0.2f)
            {
                destinationReached++;
            }
        } else {
            temple.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
