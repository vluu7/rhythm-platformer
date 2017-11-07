﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {
	
	private float checkTouchHold = 0.5f; 
	private float touchHoldTime = 0;
	private float minSwipeDistance = 50.0f;
	private float maxSwipeTime = 0.5f;
	private float fingerSwipeTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool swipe = false;

	public float speed;
	public float jump;
	float moveVelocity;
	// bool ground = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonDown (0)) {
            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
            transform.position = new Vector3(0, 4.12f, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
            transform.position = new Vector3(transform.position.x, 6.42f, -7);

        if (Input.GetKeyDown(KeyCode.S))
            transform.position = new Vector3(transform.position.x, 2.00f, -7);

        if (Input.GetKeyDown(KeyCode.D))
            transform.position = new Vector3(transform.position.x, -2.42f, -7);
		*/

		if (Input.touchCount > 0) {
			
			touchHoldTime += Input.GetTouch(0).deltaTime;

			if (touchHoldTime > checkTouchHold) {
				//touch and hold gesture
				transform.position = new Vector3(transform.position.x, -2.42f, -7);
			}

			if (Input.GetTouch(0).phase == TouchPhase.Ended) { 
				touchHoldTime = 0;
			}

			if (Input.touchCount == 2) {
				//2 finger
			}

			foreach (Touch touch in Input.touches) {

				switch (touch.phase) {
				case TouchPhase.Began:
					swipe = true;
					fingerSwipeTime = Time.time;
					fingerStartPos = touch.position;
					break;
				
				case TouchPhase.Canceled:
					swipe = false;
					break;
				
				case TouchPhase.Ended:
					float gestureTime = Time.time - fingerSwipeTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (swipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDistance) {
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) { //if swipe is horizontal
							swipeType = Vector2.right * Mathf.Sign (direction.x);
						} else { //if swipe is vertical
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}

						if (swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f) {
								//move right
								transform.position = new Vector3(transform.position.x, 6.42f, -7);
							} else {
								//move left
							}
						}

						if (swipeType.y != 0.0f ) {
							if (swipeType.y > 0.0f) {
								//move up
								transform.position = new Vector3(transform.position.x, 2.00f, -7);
							} else {
								//move down
							}
						}
					}
					break;
				}
			}
		}
	}
}

