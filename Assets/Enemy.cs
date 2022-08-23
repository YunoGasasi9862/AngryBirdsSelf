using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Animation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Fish>())
        {
            Instantiate(Animation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.collider.GetComponent<Enemy>())
        {
            return;
        }

        if(collision.GetContact(0).normal.y <=0.5) //if anything falls directly on the head
        {
            Instantiate(Animation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
