using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] Enemy[] _enemies; //array of all the available enemies


    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    void Update()
    {

       
           foreach (Enemy enemy in _enemies)
        {
            if(enemy!=null)
            {
                return;
            }
        }
      

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);



    }

}
