using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideView : MonoBehaviour
{

    CinemachineVirtualCamera cam;
    [SerializeField] GameObject Fish;
    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        cam.m_Lens.OrthographicSize = 2.94f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
