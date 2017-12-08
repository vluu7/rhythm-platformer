using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip clip;
    public GameObject PauseUI;
    public GameObject OnScreenButtons;
    private bool paused = true;
    private bool startGame = true;

    void Start()
    {
        PauseUI.SetActive(false);    
    }

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            startGame = !startGame;
        }

        if (paused && startGame)
        {
            Time.timeScale = 0;
        }
        else if (paused && !startGame)
        {
            PauseUI.SetActive(true);
            OnScreenButtons.SetActive(false);
            Time.timeScale = 0;
        }
        else if(!paused)
        {
            PauseUI.SetActive(false);
            OnScreenButtons.SetActive(true);
            Time.timeScale = 1;
        }

    }

    public void Pause()
    {
        //OnScreenButtons.SetActive(false);
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndCountdownPause(bool check)
    {
        paused = check;
        startGame = check;
    }

}
