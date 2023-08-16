using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualAim : MonoBehaviour
{
    public Camera cam;
    public Transform turret;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 4.5f;
    public float projectileLifeTime = 4.5f;

    ProjectileScript _projectileScript;
    Vector2 aimDirection;
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Fire.performed += ctx => FireTurret();
        controls.Gameplay.AimTurret.performed += ctx => aimDirection = ctx.ReadValue<Vector2>();
    }

    void Start()
    {
        _projectileScript = projectile.GetComponent<ProjectileScript>();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireTurret();
        }
        RotateTurret();
    }

    void FireTurret()
    {
        _projectileScript.speed = projectileSpeed;
        _projectileScript.lifeTime = projectileLifeTime;
        Instantiate(projectile, firePoint.position, transform.rotation);
    }

    void RotateTurret()
    {
        Vector2 direction = Input.mousePosition;
        //Vector2 direction = new Vector2(aimDirection.x, aimDirection.y);
        Vector2 distance = (Vector2)cam.ScreenToWorldPoint(direction) - (Vector2)turret.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
