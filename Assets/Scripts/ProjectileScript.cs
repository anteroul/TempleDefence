using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 4.5f;
    public float lifeTime = 4.5f;

    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
