using UnityEngine;
using System.Collections;

public class CheckTrigger : MonoBehaviour {

	public bool swordDocked = false;
	public bool dockOne = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Sword") {
			swordDocked = true;
			if (dockOne) 
				Debug.Log ("docked sword " + "one");
			else 
				Debug.Log ("docked sword " + "two");
		}
	}

	void OnTriggerExit(Collider other) {
	if (other.gameObject.tag == "Sword") {
			swordDocked = false;
			if (dockOne) 
				Debug.Log ("undocked sword " + "one");
			else 
				Debug.Log ("undocked sword " + "two");
	}
	}
		 
}
