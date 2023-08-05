using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualAim : MonoBehaviour
{
    public Camera cam;
    public Transform turret;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 4.5f;
    public float projectileLifeTime = 4.5f;
    
    private ProjectileScript _projectileScript;

    private void Start()
    {
        _projectileScript = projectile.GetComponent<ProjectileScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _projectileScript.speed = projectileSpeed;
            _projectileScript.lifeTime = projectileLifeTime;
            Instantiate(projectile, firePoint.position, transform.rotation);
        }
        RotateTurret();
    }

    private void RotateTurret()
    {
        Vector2 distance = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2)turret.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
