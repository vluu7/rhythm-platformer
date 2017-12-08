using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {

    public Animator anim;
    private int AnimationTracker = 0;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w"))
        {
            anim.Play("Tofu Slam");
        }

        if(Input.GetKeyDown("q"))
        {
            anim.Play("TofuFling");
        }

        if(Input.GetKeyDown("e"))
        {
            anim.Play("ProjectileAttack2");
        }

        if (Input.GetKeyDown("a"))
        {
            anim.Play("duck");
        }

        if (Input.GetKeyDown("z"))
        {
            anim.Play("duckingRW");
        }

        if (Input.GetKeyDown("g"))
        {
            anim.Play("finalAttack");
        }

        if (Input.GetKeyDown("d"))
        {
            GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, 2.5f, -7);
            anim.Play("spin");
        }

        if (Input.GetKeyDown("s"))
        {
            AnimationTracker = 1;
            if (AnimationTracker == 1)
            {
                //GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, 2.5f, -7);
                anim.Play("jump");
                Debug.Log("Jump");
                //ExecuteAfterTime(0.8f);
            }
        }
        else
        {
            GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, -3.01f, -7);
            AnimationTracker = 0;
        }

    }

    /*public IEnumerator ExecuteAfterTime(float time)
    {
        Debug.Log("Jumped");
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, 2.5f, -7);
        anim.Play("FoxJumpBroken");
        yield return new WaitForSeconds(time); // the program waits time seconds before continuing
        GameObject.Find("NewFox").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, -3.01f, -7);
    }*/

}
