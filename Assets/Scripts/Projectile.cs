using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 12.5f;
    public float lifeTime = 4.5f;
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
