using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    [SerializeField] LevelController controller;
    void Start()
    {
        controller = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
