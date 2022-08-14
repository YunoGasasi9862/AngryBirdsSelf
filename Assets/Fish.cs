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

    public GameManager gamemanager;
    LineRenderer lr;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        initialPos = transform.position;
        _birdisLaunched = false;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position); //the line renderer should render from transform to the initial position, thats why 0 to 1
        lr.SetPosition(1, initialPos );

        if(_birdisLaunched && rb.velocity.magnitude <=0.1)
        {
            timespent += Time.deltaTime;
        }

          if(transform.position.x> 50 || transform.position.x <-50
            || transform.position.y >50 || transform.position.y <-50 || timespent > 3)
        {
            gamemanager.GameOver();
        }
    }
    private void OnMouseDown()
    {
        sprite.color = Color.green;
        lr.enabled = true;
    }

    private void OnMouseUp()
    {
        sprite.color = Color.white;
        Vector2 directiontoFollow = initialPos - transform.position;
        rb.AddForce(directiontoFollow * Thrust);
        rb.gravityScale = 1;
        _birdisLaunched = true;
        lr.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 dragtoLocation = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(dragtoLocation.x, dragtoLocation.y);

    }
}
