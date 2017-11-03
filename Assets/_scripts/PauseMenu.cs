using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip clip;
    public GameObject PauseUI;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);    
    }

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            audioSource.Pause();
        }
        else if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            audioSource.UnPause();
        }

    }

}
