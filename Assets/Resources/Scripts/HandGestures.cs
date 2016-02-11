using UnityEngine;
using System.Collections;

public class HandGestures : MonoBehaviour {

	public Transform rightHand; 
	public Transform leftHand; 
	public static bool canGoForward = false;
	public static float rotateValue = 0.0f;
	private Transform playerCam;


	public float speed = 0.0f;
	public float maxSpeed = 50.0f;
	public float acceleration = 0.2f; 
	public bool linearSpeed = true; 

	// Use this for initialization
	void Start () {
		playerCam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		if (linearSpeed) {
			speed = 40.0f;
		} else
			speed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		ForwardGesture ();
		if (linearSpeed) {
			if (canGoForward)
				playerCam.parent.transform.Translate (playerCam.forward * Time.deltaTime * speed, Space.World);
		} else {
			playerCam.parent.transform.Translate (playerCam.forward * Time.deltaTime * speed, Space.World);
		}
		//playerCam.transform.parent.transform.Rotate (0.0f, rotateValue, 0.0f);
	}

	/**
	 * 
	 * */ 
	public void ForwardGesture() {
		if (Vector3.Distance (rightHand.position, leftHand.position) < 0.3f)  {
			if (speed < maxSpeed && !linearSpeed) {
				speed += acceleration;
			}

			canGoForward = true;
		} else {
			if (speed > 0.0f && !linearSpeed) {
				speed -= acceleration;
			}
			canGoForward = false;
		}
	}




}
