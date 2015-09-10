using UnityEngine;
using System.Collections;

public class EffectPosition : MonoBehaviour {

	Behaviour halo;

	public GameObject _parent;

	// Use this for initialization
	void Start () {
		halo = (Behaviour)gameObject.GetComponent("Halo");
		_parent = transform.root.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = _parent.transform.position;
		if (TurnManager.once == true) {
			if (this.gameObject.tag == "bcell") {
				halo.enabled = false;
			} else {
				halo.enabled = true;
			}
		}
		if (TurnManager.once == false) {
			if (this.gameObject.tag == "bcell") {
				halo.enabled = true;
			} else {
				halo.enabled = false;
			}
		}
	}
}
