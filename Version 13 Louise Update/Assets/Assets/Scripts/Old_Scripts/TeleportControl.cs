using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportControl : MonoBehaviour
{
    public float power = 5;

    Rigidbody2D rb;

    LineRenderer lr;

    Vector2 DragStartPos;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {

        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * power;

            rb.velocity = _velocity; 
        }
    }

}
