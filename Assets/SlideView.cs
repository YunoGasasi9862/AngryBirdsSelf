using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideView : MonoBehaviour
{

    CinemachineVirtualCamera cam;
    [SerializeField] Transform Fish;
    CinemachineTransposer transposer;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
 
    }
    void Start()
    {
        cam.m_Lens.OrthographicSize = 2.94f;
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       while(transposer.m_FollowOffset.x>0)
        {

            transposer.m_FollowOffset.x -= 0.002f * Time.deltaTime;

        }
        while (transposer.m_FollowOffset.y < 0)
        {

            transposer.m_FollowOffset.y += 0.002f * Time.deltaTime;

        }
    }
}
