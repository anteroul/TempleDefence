using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public Camera camera;
    public Transform gunHolder;
    public Transform firePoint;
    public GameObject projectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, firePoint.position, transform.rotation);
        }
        Rotate();
    }

    void Rotate()
    {
        Vector2 distance = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)gunHolder.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
