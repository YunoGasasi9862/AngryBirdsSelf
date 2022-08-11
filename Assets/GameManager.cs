using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   public void GameOver()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);

    }
}
