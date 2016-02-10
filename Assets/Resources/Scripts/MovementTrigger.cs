using UnityEngine;
using System.Collections;

public class MovementTrigger : MonoBehaviour {

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
		if (check1.swordDocked || check2.swordDocked) {
			MoveHoverBoard ();
			StartingWithOculus.isMoving = true;
		} else {
			StartingWithOculus.isMoving = false;
		}
	}

	public void MoveHoverBoard() {
		playerCam.parent.transform.Translate (playerCam.forward * Time.deltaTime * speed, Space.World);
	}


}
