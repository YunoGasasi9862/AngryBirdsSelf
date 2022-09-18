using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Enemy : MonoBehaviour
{

    public GameObject Animation;

    [SerializeField] Fish Fish;

    private void Start()
    {
        Fish = FindObjectOfType<Fish>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Fish>())
        {

        
            Instantiate(Animation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
      if(collision.collider.GetComponent<Enemy>())
        {
            return;
        }
        if(collision.GetContact(0).normal.y <=0.5f)
        {
           
            Instantiate(Animation, transform.position, Quaternion.identity);
            Fish.score += 5000 * 1.1f;
            Destroy(gameObject);
        }
    }
}
