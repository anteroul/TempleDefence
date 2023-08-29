using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turret;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 4.5f;
    public float projectileLifeTime = 0.5f;
    public float range = 2.5f;
    public float reloadTime = 1.2f;

#nullable enable
    GameObject? currentTarget = null;
#nullable disable

    ProjectileScript projectileScript;
    Vector2 target;
    float reloadTimer;
    bool reloaded;
    bool targetAcquired;

    GameObject[] UpdateTargets()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Awake()
    {
        targetAcquired = false;
        reloaded = true;
        reloadTimer = 0.0f;
        projectileScript = projectile.GetComponent<ProjectileScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetAcquired)
        {
            foreach (var enemy in UpdateTargets())
            {
                if (InRange(enemy.transform.position))
                {
                    currentTarget = enemy;
                    targetAcquired = true;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                target = currentTarget.transform.position;
            } else {
                targetAcquired = false;
            }
            if (InRange(target))
            {
                if (reloaded)
                {
                    FireTurret();
                }
                else
                {
                    reloadTimer += 0.1f * Time.deltaTime;
                    if (reloadTimer >= reloadTime)
                    {
                        reloaded = true;
                    }
                }
                RotateTurret(target);
            } else {
                targetAcquired = false;
            }
        }
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
        Vector2 distance = target - (Vector2)turret.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    bool InRange(Vector2 target)
    {
        float distance = Vector2.Distance(target, gameObject.transform.position);

        if (distance <= range)
        {
            return true;
        }
        
        return false;
    }
}
