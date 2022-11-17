using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartQuit()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }

    public void EasyGame()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void EndEasy()
    {
        SceneManager.LoadScene("Main Menu");
    }

    
}
