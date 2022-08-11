using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Vector3 initialPos;
    Camera cam;
    [SerializeField] float Thrust = 40f;
    [SerializeField] float timespent = 0;
    bool _birdisLaunched;
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

    private void Update()
    {

        if(_birdisLaunched && rb.velocity.magnitude <=0.1)
        {
            timespent += Time.deltaTime;
        }

          if(transform.position.x> 13 || transform.position.x <-13
            || transform.position.y >10 || transform.position.y <-10 )
        {

        }
    }
    private void OnMouseDown()
    {
        sprite.color = Color.green;
    }

    private void OnMouseUp()
    {
        sprite.color = Color.white;
        Vector2 directiontoFollow = initialPos - transform.position;
        rb.AddForce(directiontoFollow * Thrust);
        rb.gravityScale = 1;
        _birdisLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newposition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(newposition.x, newposition.y);

    }
}
