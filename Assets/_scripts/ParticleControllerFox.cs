using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerFox : MonoBehaviour {

    //Random rnd = new Random;
    public ParticleSystem ps;
    public ParticleSystem sparkOn;
    public int goodDodge;

    void Update()
    {
        int spark = Random.Range(1, 100);    

        if (7 % spark == 0)
        {
            sparkOn.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            if (goodDodge == 1)
            {
                ps.Play();
                Debug.Log("BurstA");
            }
        }

        if (Input.GetKeyDown("s"))
        {
            if (goodDodge == 1)
            {
                ps.Play();
                Debug.Log("BurstS");
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (goodDodge == 1)
            {
                ps.Play();
                Debug.Log("BurstD");
            }
        }
    }

}
