using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSoundEffects : MonoBehaviour {

    public AudioSource[] audioSources = new AudioSource[3];
    public AudioClip[] audioClips = new AudioClip[2];

    // Use this for initialization
    void Start () {
        //AudioSource audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("g"))
        {
            StartCoroutine("FinalAttackCharge");
        }

	}

    IEnumerator FinalAttackCharge()
    {
        yield return new WaitForSeconds(0.8f);
        audioSources[0].clip = audioClips[0];
        audioSources[0].Play();
        yield return new WaitForSeconds(1.5f);
        audioSources[1].clip = audioClips[1];
        audioSources[2].clip = audioClips[1];
        audioSources[1].Play();
        audioSources[2].Play();
        yield return new WaitForSeconds(0.5f);
        audioSources[1].volume = 0.9f;
        audioSources[2].volume = 0.9f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.8f;
        audioSources[2].volume = 0.8f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.7f;
        audioSources[2].volume = 0.7f;
        audioSources[3].clip = audioClips[2];
        audioSources[3].Play();
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.6f;
        audioSources[2].volume = 0.6f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.5f;
        audioSources[2].volume = 0.5f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.4f;
        audioSources[2].volume = 0.4f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.3f;
        audioSources[2].volume = 0.3f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.2f;
        audioSources[2].volume = 0.2f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0.1f;
        audioSources[2].volume = 0.1f;
        yield return new WaitForSeconds(0.2f);
        audioSources[1].volume = 0;
        audioSources[2].volume = 0;
        yield return new WaitForSeconds(0.5f);
        audioSources[0].Stop();
        audioSources[1].Stop();
        audioSources[2].Stop();
        audioSources[3].Stop();


    }

}
