using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    public GameObject GameOverUI;
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
        //GameOverUI.SetActive(false);
        anim = GetComponent<Animator>();
        FinalAttackLightHit.intensity = 0;
        FinalAttackLightCharge.intensity = 0;
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
            anim.Play("duck");
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
        //GameOverUI.SetActive(true);
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
        // J Delay: ~0.86s
        // D Delay: ~0.86s
        // S Delay: ~0.95s

        // 6.22 J
        yield return new WaitForSeconds(0.86f);
        // 10.11 S
        // 12.41 J
        // 14.68 S
        // 18.57 J
        // 21.25 D
        // 24.76 S
        // 26.34 S
        // 27.88 D
        // 29.43 J
        // 30.21 J
        // 31.04 D
        // 32.52 D
        // 34.14 S
        // 35.69 S
        // 36.04 D
        // 37.20 j
        // 37.64 j
        // 37.94 S
        // 38.70 D
        // 39.14 D
        // 39.49 J
        // 40.31 S
        // 40.68 S
        // 41.08 J
        // 41.47 J
        // 41.85 D
        // 42.61 J
        // 43.38 S
        // 43.74 D
        // 44.17 D
        // 44.93 S
        // 45.32 S
        // 45.74 J
        // 46.49 J
        // 46.91 S
        // 47.26 D
        // 48.04 D
        // 48.81 J
        // 49.59 S
        // 51.08 S
        // 52.66 J
        // 54.22 D
        // 55.82 S
        // 56.57 D
        // 57.36 S
        // 58.11 J
        // 58.86 J
        // 59.68 S
        // 1:00.43 D
        // 1:01.18 S
        // 1:01.99 D
        // 1:03.52 D
        // 1:05.08 S
        // 1:06.55 J
        // 1:08.16 J
        // 1:08.95 S
        // 1:09.71 J
        // 1:10.46 D
        // 1:11.23 D
        // 1:12.07 S
        // 1:12.82 S
        // 1:13.55 D
        // 1:14.39 S
        // 1:15.14 D
        // 1:15.92 J
        // 1:16.48 S
        // 1:17.46 S
        // 1:18.23 J
        // 1:19.00 D
        // 1:19.55 D
        // 1:20.60 S
        // 1:21.35 D
        // 1:22.18 S
        // 1:22.54 J
        // 1:22.89 J
        // 1:23.26 S
        // 1:23.62 J
        // 1:24.45 J
        // 1:25.20 J
        // 1:25.56 S
        // 1:25.96 S
        // 1:26.31 D
        // 1:26.70 D
        // 1:27.18 S
        // 1:27.53 J
        // 1:27.95 S
        // 1:28.28 S
        // 1:28.70 D
        // 1:29.17 D
        // 1:29.50 S
        // 1:29.87 J
        // 1:30.25 J
        // 1:30.60 S
        // 1:31.04 D
        // 1:31.42 S
        // 1:31.79 D
        // 1:32.17 J
        // 1:32.54 S
        // 1:32.92 S
        // 1:33.39 J
        // 1:33.74 S
        // 1:34.09 J
        // 1:34.48 D
        // 1:34.93 D
        // 1:35.28 J
        // 1:35.64 J
        // 1:36.06 S
        // 1:36.54 D
        // 1:36.85 S
        // 1:37.18 J
        // 1:37.60 D
        // 1:38.15 S
        // 1:38.35 D

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
