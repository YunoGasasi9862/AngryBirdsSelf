using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Fish : MonoBehaviour
{
 

    public CinemachineVirtualCamera cae;
    public GameManager gamemanager;
  
    private void Awake()
    {
       
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
       
  
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
 

   


}