using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Color newColor;
    public float sensitivity = 5.0f;
    public bool isLegal = true;

    private Color originalColor;
    private SpriteRenderer ren;

    void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().color;
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
}
