using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] Enemy[] _enemies; //array of all the available enemies

    public float Score;
    [SerializeField] float multiplier = 0.5f;

    bool dead = true;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    void Update()
    {

       
        foreach(Enemy enemy in _enemies)
        {
            int currentSize = _enemies.Length;
            if (enemy != null)
            {
                return;
            }
            else
            {
                if (currentSize > _enemies.Length)
                {
                    Score += 5000 * multiplier * 2;
                    multiplier += .5f;
                    Debug.Log(Score);
                    currentSize--;
                }
                Debug.Log(currentSize);
            }



        }
      






        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);



    }

}
