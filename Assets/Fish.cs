using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Fish : MonoBehaviour
{
    SpriteRenderer sprite;
    Camera cam;

  

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
   

    private void Update()
    {
    

       

        if (transform.position.x > 50 || transform.position.x < -50
          || transform.position.y > 50 || transform.position.y < -50)
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
        whosh.Play();
        lr.enabled = false;
    }

    private void OnMouseDrag()
    {

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