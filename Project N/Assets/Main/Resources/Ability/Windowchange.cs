using UnityEngine;
using System.Collections;

public class Windowchange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.Allselect == false) {
			this.gameObject.SetActive(false);
		}
	
	}
	public void ChangeWindow(){
		if (TurnManager.Allselect == true) {
			if (this.gameObject.activeSelf == false) {
				this.gameObject.SetActive (true);
			} else if
			(this.gameObject.activeSelf == true) {
				this.gameObject.SetActive (false);
			}
		}
	}
}
