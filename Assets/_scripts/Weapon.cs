using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask WhatToHit;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Awake ()
    {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No firepoint!");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();
		if(fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Debug.Log("TestShoot");
        Vector3 playerPosition = new Vector3(GameObject.FindGameObjectWithTag("Fox").transform.position.x, GameObject.FindGameObjectWithTag("Fox").transform.position.y, GameObject.FindGameObjectWithTag("Fox").transform.position.z);
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        RaycastHit2D hit = Physics2D.Raycast (firePointPosition, playerPosition - firePointPosition, 100, WhatToHit);
        Debug.DrawLine(firePointPosition, (playerPosition-firePointPosition)*100);

        if (hit.collider!= null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("Hit: " + hit.collider.name + " and did " + Damage + " damage.");
        }
    }

}
