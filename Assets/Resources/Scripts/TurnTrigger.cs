using UnityEngine;
using System.Collections;

public class TurnTrigger : MonoBehaviour {

	private CheckTrigger check1;
	private CheckTrigger check2; 

	private Transform playerCam;

	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
		playerCam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		check1 = this.transform.GetChild (0).GetComponent<CheckTrigger> ();
		check2 = this.transform.GetChild (1).GetComponent<CheckTrigger> ();
	}

	// Update is called once per frame
	void Update () {
		if (check1.swordDocked) {
			RotateHoverBoard (0.5f);
		}
		else if (check2.swordDocked) {
			RotateHoverBoard (-0.5f);
		}
	}

	public void RotateHoverBoard(float value) {
		playerCam.transform.parent.transform.Rotate (0.0f, value, 0.0f);
	}
}
