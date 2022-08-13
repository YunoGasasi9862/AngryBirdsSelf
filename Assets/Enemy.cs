using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Fish>())
        {
            Destroy(gameObject);
        }

        if(collision.collider.GetComponent<Enemy>())
        {
            return; //if the two enemy collides, dont DO ANYTHING!!!
        }

        if(collision.GetContact(0).normal.y <=0.5) //that is the box
        {
            Destroy(gameObject);
        }
    }
}
