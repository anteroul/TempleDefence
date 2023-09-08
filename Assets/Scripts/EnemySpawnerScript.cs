using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    public Transform[] path;
    public float spawnInterval;
    float spawnTime;
    float timer;

    void Awake()
    {
        enemy.GetComponent<Enemy>().pathPoints = path;
        enemy.GetComponent<Enemy>().level = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.1f * Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        spawnTime = Random.Range(1, spawnInterval);
        timer = 0;
        Instantiate(enemy, spawnPoint);
    }
}
