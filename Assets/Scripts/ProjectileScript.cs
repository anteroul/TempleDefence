using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Rock,
    Dart,
    Arrow,
    Tomahawk
}

public class ProjectileScript : MonoBehaviour
{
    SpriteRenderer ren;
    Rigidbody2D rb;

    public Type projectileType = 0;
    public int damage = 10;
    public float speed = 4.5f;
    public float lifeTime = 4.5f;
    public Sprite[] sprites;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);

        switch (projectileType)
        {
            case Type.Rock:
                damage = 10;
                speed = 4.5f;
                lifeTime = 0.5f;
                break;
            case Type.Dart:
                damage = 20;
                speed = 7.5f;
                lifeTime = 1.5f;
                break;
            case Type.Arrow:
                damage = 20;
                speed = 10.0f;
                lifeTime = 1.5f;
                break;
            case Type.Tomahawk:
                damage = 80;
                speed = 4.5f;
                lifeTime = 1.0f;
                break;
        }

        ren.sprite = sprites[(int)projectileType];
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
