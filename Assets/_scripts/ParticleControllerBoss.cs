using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerBoss : MonoBehaviour
{
    /*
     * 
     * THIS SCRIPT IS OBSOLETE, BOSS PARTICLES ARE NOW CONTROLLED IN ANIMCONTROLLER
     * 
     * 
     */

    public ParticleSystem jump;
    public ParticleSystem duck;
    public ParticleSystem spin;
    public ParticleSystem spin2;

    public ParticleSystem smog;

    public ParticleSystem testSpin;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            jump.Play();
            Debug.Log("JumpAttack");
        }

        if (Input.GetKeyDown("w"))
        {
            duck.Play();
            Debug.Log("DuckAttack");
        }

        if (Input.GetKeyDown("e"))
        {
            spin.Play();
            spin2.Play();
            //smog.Play();
            Debug.Log("SpinAttack");
        }

        if(Input.GetKeyDown("r"))
        {
            smog.Play();
            Debug.Log("Smog");
        }

    }

}