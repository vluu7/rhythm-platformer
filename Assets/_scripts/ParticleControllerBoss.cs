using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerBoss : MonoBehaviour
{

    public ParticleSystem jump;
    public ParticleSystem duck;
    public ParticleSystem spin;


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
                Debug.Log("SpinAttack");
        }
    }

}