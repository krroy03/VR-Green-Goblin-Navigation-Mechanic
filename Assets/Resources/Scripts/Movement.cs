using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;

	private GameObject playerCam; 

	public bool testingWithoutOculus = false;

	// Use this for initialization
	void Start () {
		playerCam = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (m_controller == null) {
			m_controller = SixenseInput.GetController (m_hand);
		} else {
			ForwardSpeed (m_controller.JoystickY);
			LateralMovement (m_controller.JoystickX);
		}

		Debug.DrawLine(playerCam.transform.position, playerCam.transform.position + playerCam.transform.forward, Color.red);
	}

	private float accelFactor = 0.01f; 

	void ForwardSpeed(float value) {
		
		if (m_hand == SixenseHands.RIGHT && testingWithoutOculus) {
			//playerCam.transform.Rotate (-value, 0.0f, 0.0f);
		}
		if (m_hand == SixenseHands.LEFT) {
			playerCam.transform.parent.transform.Translate (value * accelFactor * playerCam.transform.forward.normalized, Space.World);
		}
	}

	void LateralMovement(float value){
		if (m_hand == SixenseHands.RIGHT  && testingWithoutOculus) {
			playerCam.transform.parent.transform.Rotate (0.0f, value, 0.0f);

		}
		else if (m_hand == SixenseHands.LEFT  && testingWithoutOculus) {
			//playerCam.transform.Rotate ( 0.0f, 0.0f, value);
		}
	}
		
}
