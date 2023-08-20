using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public GameObject turret;
    public Color newColor;
    public float sensitivity = 5.0f;
    public bool isLegal = true;

    Color originalColor;
    SpriteRenderer ren;
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.PlaceTurret.performed += ctx => PlaceTurret();
        ren = GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * sensitivity * Time.deltaTime;
        
        transform.Translate(movement);

        if (!isLegal)
        {
            ren.color = newColor;
        }
        else
        {
            ren.color = originalColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            isLegal = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            isLegal = true;
        }
    }

    void PlaceTurret()
    {
        if (isLegal)
        {
            Instantiate(turret, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
