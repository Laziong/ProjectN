using UnityEngine;
using System.Collections;

public class Edestroy2 : MonoBehaviour {
	public GameObject GM;
	Renderer Ccolor;

	public bool hitfriendB;

	// Use this for initialization
	void Start () {
		hitfriendB = false;
	}
	
	// Update is called once per frame
	//移動範囲削除
	void Update () {
		if (TurnManager.blackpoint == 0 || TurnManager.Allselect == false) {
			Destroy(this.gameObject);
		}
	}
	void OnTriggerStay(Collider collision){
		if (collision.gameObject.tag == "black") {
			hitfriendB = true;
		} 
		if (collision.gameObject.tag == "cell") {
			hitfriendB = false;
			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			collision.gameObject.tag = ("moveeffect");
		}
	}
}
