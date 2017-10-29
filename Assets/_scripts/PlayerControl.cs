using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public float jump;
	float moveVelocity;
	bool ground = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonDown (0)) {
            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
            transform.position = new Vector3(0, 4.12f, 0);
        }*/

        if (Input.GetKeyDown(KeyCode.A))
            transform.position = new Vector3(transform.position.x, 6.42f, -7);

        if (Input.GetKeyDown(KeyCode.S))
            transform.position = new Vector3(transform.position.x, 2.00f, -7);

        if (Input.GetKeyDown(KeyCode.D))
            transform.position = new Vector3(transform.position.x, -2.42f, -7);

    }
}
