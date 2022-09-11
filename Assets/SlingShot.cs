using Cinemachine.Utility;
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

    Camera cam;

    bool isMouseDown;
    
     Vector3 currentPos;

    [SerializeField] float maxlength;
    private void Awake()
    {
        cam = Camera.main;
        Fish = GameObject.FindGameObjectWithTag("Fish");
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


            currentPos = center.position + Vector3.ClampMagnitude(currentPos - center.position, maxlength);  //this formula clamps the slingshot to that point

            strips[0].SetPosition(1, currentPos);
            strips[1].SetPosition(1, currentPos);

            Fish.transform.position = currentPos;

        }
        else
        {
            strips[0].SetPosition(1, idlePos.position);
            strips[1].SetPosition(1, idlePos.position);

            Fish.GetComponent<Rigidbody2D>().AddForce(new Vector3(Fish.transform.position - idlePos)));
        }


    }
}
