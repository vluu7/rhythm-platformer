using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    public Animator anim;
    private int AnimationTracker = 0;
    //public float speed;

    //Boss Particle Systems/Game Objects
    public ParticleSystem jumpBoss;
    public ParticleSystem duckBoss;
    public ParticleSystem duckProjectile;
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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

    IEnumerator FinalAttack()
    {
        //runningSparks.Pause();
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, 2.8f, -11.33f);
        anim.Play("finalAttack");
        yield return new WaitForSeconds(1.2f); // the program waits time seconds before continuing
        FoxFinalAttack.Play();
        FoxFinalAttack1.Play();
        yield return new WaitForSeconds(0.7f);
        FoxFinalAttackBall.Play();
        FoxFinalAttackBall1.Play();
        yield return new WaitForSeconds(0.5f);
        bossDie.Play();
        yield return new WaitForSeconds(1.8f);
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("NewFox").transform.position.x, -3.01f, -11.33f);
        //runningSparks.Play();
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

    IEnumerator BossCueJump()
    {
        jumpBoss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("lunge");
    }

    IEnumerator BossCueDuck()
    {
        duckBoss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("projectile");
        yield return new WaitForSeconds(0.2f);
        duckProjectile.Play();
        /*float step = speed * Time.deltaTime;
        Instantiate(spike, new Vector3(GameObject.FindGameObjectWithTag("weapon").transform.position.x, -2, -7), Spike2.rotation);
        spike.transform.position = Vector3.MoveTowards(transform.position, FoxPlayer.position, step);
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(spike);*/
    }

    IEnumerator BossCueSmog()
    {
        spinBoss.Play();
        spin2Boss.Play();
        yield return new WaitForSeconds(0.5f);
        anim.Play("smog");
        yield return new WaitForSeconds(0.25f);
        smogBoss.Play();
    }

}
