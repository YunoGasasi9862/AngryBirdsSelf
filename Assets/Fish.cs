using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fish : MonoBehaviour
{
 

    public GameManager gamemanager;
    public float score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
  
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

        scoreText.text = "SCORE: " + score;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Enemy>())
        {
            score += 5000 * 1.1f;
            Debug.Log(score);
        }
    }




}