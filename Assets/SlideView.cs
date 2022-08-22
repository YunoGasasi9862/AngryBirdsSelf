using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideView : MonoBehaviour
{

    CinemachineVirtualCamera cam;
    [SerializeField] GameObject Fish;
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
    void Update()
    {
       while(transposer.m_FollowOffset.x>0)
        {
            float x;
            float y;

            x = Fish.transform.position.x;
            y = Fish.transform.position.y;

            transposer.m_FollowOffset = new Vector3(0,0, -10);
          

        }
    }
}
