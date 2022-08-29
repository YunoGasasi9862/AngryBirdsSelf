using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] Enemy[] _enemies; //array of all the available enemies

    void Update()
    {
        foreach(Enemy enemy in _enemies)  //for every enemy stashed in the array
        {

        }

    }

    private void OnEnable() //when the script gets enabled
    {
        _enemies = FindObjectsOfType<Enemy>(); //find all the objects not a single one
    }
}
