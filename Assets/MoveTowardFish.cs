using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardFish : MonoBehaviour
{
    [SerializeField] Transform Fish;
    Rigidbody2D rb;
    [SerializeField] bool Allow = true;
    void Start()
    {
        Fish = GameObject.FindObjectOfType<Fish>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Allow)
        {
            Vector3 FollowDirection = Fish.position - transform.position;
            rb.AddForce(FollowDirection * Time.deltaTime);
        }
           
        if(transform.position.x==Fish.position.x && transform.position.y == Fish.position.y)
        {
            Allow = false;
        }

        
           

        
   

        

    }
}
