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
        Left = background.transform.GetChild(1);
        Top = background.transform.GetChild(2);
        Bottom = background.transform.GetChild(3);

    }
    private void Start()
    {
        initialPos = transform.position;
        _birdisLaunched = false;
        // cae.m_Lens.OrthographicSize = 20f;
    }

    private void Update()
    {
       

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, initialPos);

       if(_birdisLaunched && rb.velocity.magnitude <=0.1f)
        {
            timespent += Time.deltaTime;
        }

        if (transform.position.x > 50 || transform.position.x < -50
          || transform.position.y > 50 || transform.position.y < -50 || timespent > 3)
        {
            gamemanager.GameOver();
        }

        // SizeUpCamera();

    }
    private void OnMouseDown()
    {
        sprite.color = Color.green;
        lr.enabled = true;


    }

    private void OnMouseUp()
    {
        sprite.color = Color.white;

        Vector3 follow = initialPos - transform.position;
        rb.AddForce(follow * Thrust);

        rb.gravityScale = 1;
        _birdisLaunched = true;
        whosh.Play();
        lr.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 Follow = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Follow.x, Follow.y);

        checkBounds();
    }


    void checkBounds()
    {
        if (transform.position.x > Right.position.x)
        {
            transform.position = new Vector2(Right.position.x - 2, transform.position.y);  //this keeps the bird inbound hopefully
        }

        if (transform.position.x < Left.position.x)
        {
            transform.position = new Vector2(Left.position.x + 2, transform.position.y);  //this keeps the bird inbound hopefully
        }
        if (transform.position.y < Bottom.position.y)
        {
            transform.position = new Vector2(transform.position.x, Bottom.position.y + 2);  //this keeps the bird inbound hopefully
        }
        if (transform.position.y > Top.position.y)
        {
            transform.position = new Vector2(transform.position.x, Top.position.y - 2);  //this keeps the bird inbound hopefully
        }
    }



}