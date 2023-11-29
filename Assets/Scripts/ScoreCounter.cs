using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int level;
    public int score;
    public string enemyType;
    public bool alive = true;
    int health;
    int money;
    float damage;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        health = 100;
        enemyType = IGameManager.GetType(level);
        money = level * 36;
        damage = getDamage();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            score = (int)(level * damage);
        }
    }

    float getDamage()
    {
        return (level * 2) + (money / 3);
    }
}
