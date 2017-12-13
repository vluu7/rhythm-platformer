﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    public GameObject GameOverUI;
    public GameObject GameOverUILose;
    public CanvasGroup uiElement;
    public Light FinalAttackLightHit;
    public Light FinalAttackLightCharge;
    private int AnimationTracker = 0;
    //public float speed;

    // The song (actually) ends around 100 seconds in
    public float timeLeft = 100f;

    //Boss Particle Systems/Game Objects
    public ParticleSystem jumpBoss;
    public ParticleSystem duckBoss;
    public ParticleSystem duckProjectile;
    public ParticleSystem BossSecondAttackSweep;
    public ParticleSystem spinBoss;
    public ParticleSystem spin2Boss;
    public ParticleSystem smogBoss;
    public ParticleSystem bossDie;

    /*public Transform SpawnPoint;
    public Transform Spike2;
    public GameObject spike;*/

    //Fox Particle Systems/ GameObjects
    public ParticleSystem testSpin;
    public ParticleSystem runningSparks;
    public ParticleSystem FoxFinalAttack;
    public ParticleSystem FoxFinalAttack1;
    public ParticleSystem FoxFinalAttackBall;
    public ParticleSystem FoxFinalAttackBall1;
    //public Transform FoxPlayer;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RoadMap());
        anim = GetComponent<Animator>();
        FinalAttackLightHit.intensity = 0;
        FinalAttackLightCharge.intensity = 0;
        GameOverUI.SetActive(false);
        GameOverUILose.SetActive(false);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    IEnumerator LightFadeIn(Light lightSource)
    {

        for (int i = 0; i < 16; i++)
        {
            lightSource.intensity = i;
            yield return new WaitForSeconds(0.01f);
            if(i == 15)
            {
                for(int z = i; z >= 0; z--)
                {
                    lightSource.intensity = z;
                    yield return new WaitForSeconds(0.09f);
                }
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (Input.GetKeyDown("q"))
        {
            StartCoroutine("BossCueJump");
        }

        if (Input.GetKeyDown("w"))
        {
            StartCoroutine("BossCueDuck");
        }

        if (Input.GetKeyDown("e"))
        {
            StartCoroutine("BossCueSmog");
        }

        if (Input.GetKeyDown("s"))
        {
            StartCoroutine("FoxDuck");
        }

        if (Input.GetKeyDown("z"))
        {
            anim.Play("duckingRW");
        }

        if (Input.GetKeyDown("g"))
        {
            StartCoroutine("FinalAttack");
        }

        if (Input.GetKeyDown("d"))
        {
            //GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, 2.5f, -7);
            anim.Play("spin");
        }

        if (Input.GetKeyDown("a"))
        {
            AnimationTracker = 1;
            if (AnimationTracker == 1)
            {
                StartCoroutine("ExecuteAfterTimeJump");
                Debug.Log("jump");
            }
        }
        /*else
        {
            GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, -3.01f, -7);
            AnimationTracker = 0;
        }*/

    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.25f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
        
        print("done");
    }

    IEnumerator FoxDuck()
    {
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, -4.0f, -11.33f);
        anim.Play("duck");
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, -3.01f, -11.33f);
    }

    IEnumerator FinalAttack()
    {
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, 2.8f, -11.33f);
        anim.Play("finalAttack");
        yield return new WaitForSeconds(1.2f); // the program waits time seconds before continuing
        StartCoroutine(LightFadeIn(FinalAttackLightCharge));
        FoxFinalAttack.Play();
        FoxFinalAttack1.Play();
        yield return new WaitForSeconds(0.7f);
        FoxFinalAttackBall.Play();
        FoxFinalAttackBall1.Play();
        yield return new WaitForSeconds(0.5f);
        bossDie.Play();
        StartCoroutine(LightFadeIn(FinalAttackLightHit));
        yield return new WaitForSeconds(1.1f);
        GameOverUI.SetActive(true);
        FadeIn();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, -3.01f, -11.33f);
    }

    IEnumerator ExecuteAfterTimeJump()
    {
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, 0.5f, -11.33f);
        //yield return new WaitForSeconds(0.009f); // the program waits time seconds before continuing
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, 1, -11.33f);
        anim.Play("jump");
        yield return new WaitForSeconds(0.25f); // the program waits time seconds before continuing
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, -3.01f, -11.33f);
        Debug.Log("Jumped");
    }

    // total time elapsed: ~0.86s
    IEnumerator BossCueJump()
    {
        jumpBoss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("lunge");                     // 0.47s
        yield return new WaitForSeconds(0.15f);
        duckProjectile.Play();
    }

    // total time elapsed: ~0.86s
    IEnumerator BossCueDuck()
    {
        duckBoss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("projectile");                // ~0.47s
        yield return new WaitForSeconds(0.2f);
        BossSecondAttackSweep.Play();
        /*float step = speed * Time.deltaTime;
        Instantiate(spike, new Vector3(GameObject.FindGameObjectWithTag("weapon").transform.position.x, -2, -7), Spike2.rotation);
        spike.transform.position = Vector3.MoveTowards(transform.position, FoxPlayer.position, step);
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(spike);*/
    }

    // total time elapsed: ~0.95s
    IEnumerator BossCueSmog()
    {
        spinBoss.Play();
        spin2Boss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("smog");                      // ~0.55s
        yield return new WaitForSeconds(0.25f);
        smogBoss.Play();
    }

    // total seconds until the song ends = 100 !!!
    IEnumerator RoadMap()
    {
        /* 'tutorial' */
        // J Delay: ~0.7s
        // D Delay: ~0.7s
        // S Delay: ~0.95s

        // 6.22 J
        yield return new WaitForSeconds(5.58f);
        StartCoroutine("BossCueJump");
        // 10.11 S
        yield return new WaitForSeconds(3.58f);
        StartCoroutine("BossCueSmog");
        // 14.68 D
        yield return new WaitForSeconds(4.23f);
        StartCoroutine("BossCueDuck");
        // 18.57 J
        yield return new WaitForSeconds(3.19f);
        StartCoroutine("BossCueJump");
        // 21.25 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 24.76 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 26.34 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 27.88 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 29.43 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 30.21 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 31.04 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 32.52 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 34.14 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 35.69 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 36.04 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 37.20 j
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 37.64 j
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 37.94 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 38.70 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 39.14 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 39.49 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 40.31 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 40.68 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 41.08 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 41.47 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 41.85 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 42.61 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 43.38 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 43.74 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 44.17 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 44.93 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 45.32 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 45.74 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 46.49 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 46.91 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 47.26 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 48.04 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 48.81 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 49.59 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 51.08 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 52.66 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 54.22 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 55.82 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 56.57 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 57.36 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 58.11 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 58.86 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 59.68 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 60.43 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 61.18 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 61.99 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 63.52 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 65.08 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 66.55 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 68.16 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 68.95 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 69.71 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 70.46 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 71.23 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 72.07 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 72.82 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 73.55 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 74.39 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 75.14 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 75.92 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 76.48 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 77.46 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 78.23 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 79.00 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 79.55 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 80.60 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 81.35 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 82.18 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 82.54 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 82.89 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 83.26 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 83.62 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 84.45 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 85.20 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 85.56 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 85.96 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 86.31 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 86.70 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 87.18 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 87.53 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 87.95 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 88.28 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 88.70 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 89.17 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 89.50 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 89.87 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 90.25 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 90.60 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 91.04 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 91.42 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 91.79 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 92.17 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 92.54 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 92.92 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 93.39 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 93.74 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 94.09 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 94.48 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 94.93 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 95.28 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 95.64 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 96.06 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 96.54 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 96.85 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 97.18 J
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueJump");
        // 97.60 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");
        // 98.15 S
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueSmog");
        // 98.35 D
        yield return new WaitForSeconds(0.86f);
        StartCoroutine("BossCueDuck");

        /*

        // if the player has at least 75% charge, then the final attack is done
        if()
        {
            
        }

        else
        {
            
        }

        */


    }

}

