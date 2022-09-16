using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [SerializeField] LineRenderer[] strips;
    [SerializeField] Transform[] stripPositions;
    [SerializeField] Transform center;
    [SerializeField] Transform idlePos;


    [SerializeField] GameObject Fish;
    [SerializeField] Rigidbody2D FishRigid;

    [SerializeField] float speed;

    [SerializeField] bool _birdisLaunched;


    [SerializeField] float timespent = 0;


    [SerializeField] GameManager gamemanager;

    [SerializeField] AudioSource whosh;

    Camera cam;

    bool isMouseDown;
    
     Vector3 currentPos;

    [SerializeField] float maxlength;
    private void Awake()
    {
        cam = Camera.main;
        Fish = GameObject.FindGameObjectWithTag("Fish");
        FishRigid = Fish.GetComponent<Rigidbody2D>();
        _birdisLaunched = false;
        gamemanager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        Fish.GetComponent<SpriteRenderer>().color = Color.red;

      
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Vector3 move = center.position - Fish.transform.position;
        FishRigid.AddForce(move * speed);
        FishRigid.gravityScale = 1;

        //change the rotation
        FishRigid.freezeRotation = false;
        _birdisLaunched = true;
        Fish.GetComponent<SpriteRenderer>().color = Color.white;

        whosh.Play();
    }

    void Start()

    {
        strips[0].SetPosition(0, stripPositions[0].transform.position);
        strips[1].SetPosition(0, stripPositions[1].transform.position);



        strips[1].SetPosition(1, idlePos.position);
        strips[0].SetPosition(1, idlePos.position);

    }



    void Update()
    {
        if(isMouseDown)
        {
            Vector3 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);


            MousePos.z = 10;

            currentPos = MousePos;

            currentPos = center.position + Vector3.ClampMagnitude(currentPos - center.position, maxlength);

            strips[0].SetPosition(1, currentPos);
            strips[1].SetPosition(1, currentPos);

            Fish.transform.position = currentPos;

        }
        else
        {
            strips[0].SetPosition(1, idlePos.position);
            strips[1].SetPosition(1, idlePos.position);

            
        }


        if(_birdisLaunched && FishRigid.velocity.magnitude <=0.1f)  //if the speed has slowed down, start counting!
        {
            timespent += Time.deltaTime;
        }

        if(timespent >3f)
        {
            gamemanager.GameOver();
        }

    }
}
