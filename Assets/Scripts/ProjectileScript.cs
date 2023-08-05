using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 4.5f;
    public float lifeTime = 4.5f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
