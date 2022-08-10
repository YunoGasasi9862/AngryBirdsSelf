using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Vector3 initialPos;
    Camera cam;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    private void Start()
    {
        initialPos = transform.position;
    }
    private void OnMouseDown()
    {
        sprite.color = Color.green;
    }

    private void OnMouseUp()
    {
        sprite.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 newposition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(newposition.x, newposition.y);

    }
}
