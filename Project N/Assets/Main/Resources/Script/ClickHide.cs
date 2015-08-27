using UnityEngine;
using System.Collections;

public class ClickHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "Down") {
			this.gameObject.SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.blackpoint == 0 || TurnManager.whitepoint == 0) {
			if (this.gameObject.name == "Down") {
				this.gameObject.SetActive (false);
			}else{
				this.gameObject.SetActive(true);
			}
		}
	}
	public void HideButton(){
		if (this.gameObject.activeSelf == true) {
			this.gameObject.SetActive (false);
		} else if
			(this.gameObject.activeSelf == false) {
			this.gameObject.SetActive (true);
		}
	}
}
