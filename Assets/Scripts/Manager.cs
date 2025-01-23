using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameManager gameManagerScript;

   public void RestartGame()
    {
        gameManagerScript.disableEndGameContainer();
        gameManagerScript.RestartGame();
        
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
