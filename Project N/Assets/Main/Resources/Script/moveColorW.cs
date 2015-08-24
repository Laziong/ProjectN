using UnityEngine;
using System.Collections;

public class moveColorW : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.Allselect == false) {
			this.GetComponent<Renderer> ().material.color = Color.white;
			this.gameObject.tag = ("cell");
		}
	}
	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "moveeffect") {
			this.GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
