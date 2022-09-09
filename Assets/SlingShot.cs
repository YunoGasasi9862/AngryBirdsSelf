using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [SerializeField] LineRenderer[] strips;
    [SerializeField] Transform[] stripPositions;
    [SerializeField] Transform center;
    [SerializeField] Transform idlePos;

    Camera cam;

    bool isMouseDown;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }

    void Start()

    {

        strips[0].SetPosition(0, stripPositions[0].position);
        strips[1].SetPosition(0, stripPositions[1].position); //setting the first positions of the line renderer


        strips[0].SetPosition(1, idlePos.position);
        strips[1].SetPosition(1, idlePos.position);

    }



    void Update()
    {
        if(isMouseDown)
        {
            Vector3 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            MousePos.z = 10; //making sure that its the front

            strips[0].SetPosition(1, MousePos);
            strips[1].SetPosition(1, MousePos);

        }
        else
        {
            strips[0].SetPosition(1, idlePos.position);
            strips[1].SetPosition(1, idlePos.position);

        }


    }
}
