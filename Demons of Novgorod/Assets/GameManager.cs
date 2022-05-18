using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            print("GameOver");

            //Restart Game

            Invoke("Restart", 4f);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
