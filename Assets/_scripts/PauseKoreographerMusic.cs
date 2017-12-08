using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseKoreographerMusic : MonoBehaviour {

    public AudioSource Audio;
    private bool musicCue;
    private int pauseCounter = 0;

    void Update()
    {
        if(musicCue)
        {
            Audio.Pause();
        }
        else if (pauseCounter == 0)
        {
            Audio.UnPause();
            pauseCounter = 1;
        }
    }

    public void PauseMusic(bool pause)
    {
        musicCue = pause;
    }

}
