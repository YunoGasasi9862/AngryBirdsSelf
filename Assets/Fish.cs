using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Fish : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Vector3 initialPos;
    Camera cam;
    [SerializeField] float Thrust = 40f;
    [SerializeField] float timespent = 0;
    bool _birdisLaunched;

    public CinemachineVirtualCamera cae;
    public GameManager gamemanager;
    LineRenderer lr;
    bool onmouseDown = false;
    AudioSource whosh;

    GameObject background;
    Transform Right;
    Transform Left;
    Transform Top;
    Transform Bottom;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        lr = GetComponent<LineRenderer>();
        whosh = GetComponent<AudioSource>();

        background = GameObject.Find("Background");
        Right = background.transform.GetChild(0);

    }
    private void Start()
    {
        initialPos = transform.position;
        _birdisLaunched = false;
        cae.m_Lens.OrthographicSize = 20f;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position); //the line renderer should render from transform to the initial position, thats why 0 to 1
        lr.SetPosition(1, initialPos);

        if(_birdisLaunched && rb.velocity.magnitude <=0.1)
        {
            timespent += Time.deltaTime;
        }


          if(transform.position.x> 50 || transform.position.x <-50
            || transform.position.y >50 || transform.position.y <-50 || timespent > 3)
        {
            gamemanager.GameOver();
        }

        if (cae.m_Lens.OrthographicSize >= 5.2f && onmouseDown==false)
        {
            cae.m_Lens.OrthographicSize -= .01f;
        }

        if (onmouseDown == true)
        {
            if (cae.m_Lens.OrthographicSize <= 15f)
            {
                cae.m_Lens.OrthographicSize += 0.01f;
            }
        }
    }
    private void OnMouseDown()
    {
        sprite.color = Color.green;
        lr.enabled = true;
        onmouseDown = true;


    }

    private void OnMouseUp()
    {
        sprite.color = Color.white;
        Vector3 directiontoFollow = initialPos-transform.position;
        rb.AddForce(directiontoFollow * Thrust);
        rb.gravityScale = 1;
        _birdisLaunched = true;
        whosh.Play();
        lr.enabled = false;
        onmouseDown = false;
    }

    private void OnMouseDrag()
    {
        Vector3 dragtoFollow = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(dragtoFollow.x, dragtoFollow.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
