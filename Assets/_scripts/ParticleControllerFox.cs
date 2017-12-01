using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerFox : MonoBehaviour {

    public ParticleSystem ps;
    public int goodDodge;

    void Update()
    {
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
