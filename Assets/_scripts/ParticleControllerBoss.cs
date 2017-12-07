using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerBoss : MonoBehaviour
{

    public ParticleSystem jump;
    public ParticleSystem duck;
    public ParticleSystem spin;
    public ParticleSystem spin2;

    public ParticleSystem testSpin;


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
                Debug.Log("SpinAttack");
        }



    }

}