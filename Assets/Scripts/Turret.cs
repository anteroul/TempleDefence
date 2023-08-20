using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    public Transform turret;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 4.5f;
    public float projectileLifeTime = 0.5f;
    public float range = 2.5f;
    public float reloadTime = 1.2f;

    GameObject[] enemies;
    ProjectileScript projectileScript;
    float reloadTimer;
    bool reloaded;

    void UpdateTargets()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Awake()
    {
        reloaded = true;
        reloadTimer = 0.0f;
        projectileScript = projectile.GetComponent<ProjectileScript>();
        UpdateTargets();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloaded)
        {
            if (enemies.Length > 0)
            {
                foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    float distance = Vector2.Distance(enemy.transform.position, gameObject.transform.position);
                    if (distance <= range)
                    {
                        FireTurret();
                    }
                    RotateTurret(enemy.transform.position);
                }
            }
        } else {
            reloadTimer += 0.1f * Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                reloaded = true;
            }
        }
        UpdateTargets();
    }

    void FireTurret()
    {
        projectileScript.speed = projectileSpeed;
        projectileScript.lifeTime = projectileLifeTime;
        Instantiate(projectile, firePoint.position, transform.rotation);
        reloaded = false;
        reloadTimer = 0.0f;
    }

    void RotateTurret(Vector2 target)
    {
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
