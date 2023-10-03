using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class GameManag
{
    public int kills = 0;
    public int _money = 0;
    public int _health;

    public int score = 100;
    public bool gameOver = false;
    public Temple temple;

    void Start()
    {
        temple.GetHealth();
    }

    bool GameOver()
    {
        if (_health <= 0)
        {
            return true;
        }
        return false;
    }
}
