using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideView : MonoBehaviour
{

    CinemachineVirtualCamera cam;
    [SerializeField] GameObject Fish;
    CinemachineTransposer transposer;

    float Time = 10;
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
    void Update()
    {
       while(transposer.m_FollowOffset.x!=0)
        {
            transposer.m_FollowOffset.x -= 0.002f;

        }
    }
}
