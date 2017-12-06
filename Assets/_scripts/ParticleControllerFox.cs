using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerFox : MonoBehaviour {

    //Random rnd = new Random;
    public ParticleSystem psGoodDodge;
    public ParticleSystem psJump;
    public ParticleSystem psDuck;
    public ParticleSystem psSpin;
    public ParticleSystem sparkOn;

    public ParticleSystem FA1;
    public ParticleSystem FA2;
    public ParticleSystem FA3;
    public ParticleSystem FA4;
    public ParticleSystem FA5;

    public int goodDodge;

    private int finalAttack = 0;

    void Update()
    {
        int spark = Random.Range(1, 100);    

        if (33 % spark == 0)
        {
            sparkOn.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            if (goodDodge == 1)
            {
                psJump.Play();
                Debug.Log("BurstA");
            }
        }

        if (Input.GetKeyDown("s"))
        {
            if (goodDodge == 1)
            {
                psDuck.Play();
                Debug.Log("BurstS");
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (goodDodge == 1)
            {
                psSpin.Play();
                Debug.Log("BurstD");
            }
        }

        if (Input.GetKeyDown("f"))
        {
            if (goodDodge == 1)
            {
                psGoodDodge.Play();
                Debug.Log("BurstD");
            }
        }

        if (Input.GetKeyDown("x"))
        {
            if (finalAttack % 2 == 0)
            {
                FA1.Play();
                FA2.Play();
                FA3.Play();
                FA4.Play();
                FA5.Play();
                Debug.Log("FABurst");
            }
            else
            {
                FA1.Stop();
                FA2.Stop();
                FA3.Stop();
                FA4.Stop();
                FA5.Stop();
            }
            finalAttack += 1;
        }

    }

}
