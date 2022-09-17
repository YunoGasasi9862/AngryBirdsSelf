using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SocialPlatforms.Impl;

public class Fish : MonoBehaviour
{
 

    public GameManager gamemanager;
    [SerializeField] int score = 5000;
  
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Enemy>())
        {
            score += 5000;
            Debug.Log(score);
        }
    }




}