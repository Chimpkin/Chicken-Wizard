using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
 
    public bool gameIsPaused = false;
    public GameUI script;

    public float timeLeft = 10;
    public bool timerIsOn = false;
    public Text timerText;

    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        timerIsOn = true;
   
        
    }


    void Update()
    {
        if (timerIsOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTime(timeLeft);
            }

            else
            {
                Debug.Log("Time out!");
                timeLeft = 0;
                timerIsOn = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        Debug.Log("Scene paused!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }

    void DisplayTime(float timeToShow)
    {
        timeToShow += 1;
        float minutes = Mathf.FloorToInt(timeToShow / 60);
        float seconds = Mathf.FloorToInt(timeToShow % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
