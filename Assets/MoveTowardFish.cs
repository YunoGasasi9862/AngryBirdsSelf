using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveTowardFish : MonoBehaviour
{
    [SerializeField] Transform Fish;
    Rigidbody2D rb;
    [SerializeField] bool Allow = true;
    [SerializeField] CinemachineVirtualCamera cam;
    void Start()
    {
        Fish = GameObject.FindObjectOfType<Fish>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.m_Lens.OrthographicSize = 5f;

        if (Allow)
        {
            Vector3 FollowDirection = Fish.position - transform.position;
            rb.AddForce(FollowDirection * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Fish")
        {
            Allow = false;
            Vector3 velocity = rb.velocity;
            velocity.x = 0f;
            velocity.y = 0f;
            rb.velocity = velocity;

        }
    }
}
