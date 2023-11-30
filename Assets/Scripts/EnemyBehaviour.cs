using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    public Sprite[] sprites;
    public bool alive = false;
    public int health;
    SpriteRenderer ren;

    void Awake()
    {
        ren = gameObject.GetComponent<SpriteRenderer>();
        ren.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive())
        {
            if (health <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                alive = false;
            }
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public SpriteRenderer GetRenderer()
    {
        return ren;
    }

    public bool IsAlive()
    {
        return alive;
    }
}
