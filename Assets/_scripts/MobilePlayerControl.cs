using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobilePlayerControl : MonoBehaviour {

	public Animator anim;
	private int AnimationTracker = 0;
	//public float speed;

	//Boss Particle Systems/Game Objects
	public ParticleSystem jumpBoss;
	public ParticleSystem duckBoss;
	public ParticleSystem duckProjectile;
	public ParticleSystem spinBoss;
	public ParticleSystem spin2Boss;
	public ParticleSystem smogBoss;
	public ParticleSystem bossDie;

	/*public Transform SpawnPoint;
    public Transform Spike2;
    public GameObject spike;*/

	//Fox Particle Systems/ GameObjects
	public ParticleSystem testSpin;
	public ParticleSystem runningSparks;
	public ParticleSystem FoxFinalAttack;
	public ParticleSystem FoxFinalAttack1;
	public ParticleSystem FoxFinalAttackBall;
	public ParticleSystem FoxFinalAttackBall1;
	//public Transform FoxPlayer;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

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

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
            transform.position = new Vector3(0, 4.12f, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
            transform.position = new Vector3(transform.position.x, 6.42f, -7);

        if (Input.GetKeyDown(KeyCode.S))
            transform.position = new Vector3(transform.position.x, 2.00f, -7);

        if (Input.GetKeyDown(KeyCode.D))
            transform.position = new Vector3(transform.position.x, -2.42f, -7);


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
				StartCoroutine("FinalAttack");
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
								StartCoroutine("FinalAttack");
							} else {
								//move left
							}
						}

						if (swipeType.y != 0.0f ) {
							if (swipeType.y > 0.0f) {
								AnimationTracker = 1;
								if (AnimationTracker == 1)
								{
									StartCoroutine("ExecuteAfterTimeJump");
									Debug.Log("jump");
								}
							} else {
								anim.Play("duckingRW");
							}
						}
					}
					break;
				}
			}
		}
	}
}
