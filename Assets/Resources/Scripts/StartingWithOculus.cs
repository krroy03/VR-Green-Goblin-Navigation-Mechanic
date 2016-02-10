using UnityEngine;
using UnityEditor;
using System.Collections;

public class StartingWithOculus : MonoBehaviour {
	private Transform originalParent; 
	private Transform originalChild1;
	private Transform originalChild2; 

	public static bool isMoving = false; 
	private bool parented = true;
	// Use this for initialization
	void Start () {
		originalParent = this.transform.parent;
		originalChild1 = this.transform.GetChild (0);
		originalChild2 = this.transform.GetChild (1);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if (!parented) {
				// parent objects to oculus camera 
				parentObjects (this.transform, true);
			}
		} else {
			if (parented) {
				// unparent objects from oculus camera and to cam container
				parentObjects (originalParent, false);
			}
		}
	}

	void parentObjects(Transform parent, bool isParented) {
		if (PlayerSettings.virtualRealitySupported) {
			this.transform.GetChild (0).SetParent (parent);
			this.transform.GetChild (0).SetParent (parent);
			parented = isParented;
		}
	}
}
