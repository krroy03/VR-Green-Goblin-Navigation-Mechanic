﻿using UnityEngine;
using System.Collections;

public class KeyControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		KeyMovement ();
	}

	public float keySpeed = 5.0f; 
	public float keyRotation = 10.0f;
	public float keyAcceleration = 0.2f;
	public float keyMaxSpeed = 50.0f;

	void KeyMovement() {
		if (Input.GetKey (KeyCode.W)) {
			if (keySpeed < keyMaxSpeed) {
				keySpeed += keyAcceleration;
			}
			Debug.Log ("working");

		} 
		if (Input.GetKey (KeyCode.A)) {
			this.transform.Rotate (0.0f, -keyRotation, 0.0f);

		} 
		if (Input.GetKey (KeyCode.S)) {
			if (keySpeed > 0.0f)
				keySpeed -= keyAcceleration; 

		} 
		if (Input.GetKey (KeyCode.D)) {
			this.transform.Rotate (0.0f, keyRotation, 0.0f);

		}

		this.transform.Translate (this.transform.GetChild(0).forward * Time.deltaTime * keySpeed, Space.World);

	}

}
