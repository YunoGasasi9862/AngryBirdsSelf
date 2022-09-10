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
    
     Vector3 currentPos;

    [SerializeField] float maxlength;
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
        strips[0].SetPosition(0, stripPositions[0].transform.position);
        strips[1].SetPosition(0, stripPositions[1].transform.position);


        strips[0].SetPosition(1, idlePos.position);
        strips[1].SetPosition(1, idlePos.position);

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

        }
        else
        {
            strips[0].SetPosition(1, idlePos.position);
            strips[1].SetPosition(1, idlePos.position);
        }


    }
}
