using UnityEngine;
using System.Collections;

public class NearCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (TurnManager.Allselect == false) {
			this.GetComponent<Camera>().enabled = false;
		}else{
			this.GetComponent<Camera>().enabled = true;
		}
	}
}
