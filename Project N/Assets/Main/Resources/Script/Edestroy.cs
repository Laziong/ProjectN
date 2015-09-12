using UnityEngine;
using System.Collections;

public class Edestroy : MonoBehaviour {
	public GameObject GM;
	Renderer Ccolor;

	public bool hitfriendW;

	public Collider collision;

	// Use this for initialization
	void Start () {
		hitfriendW = false;
	}
	
	// Update is called once per frame
	//移動範囲削除
	void Update () {
		if (TurnManager.whitepoint == 0 || TurnManager.Allselect == false) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerStay(Collider collision){

		if (collision.gameObject.tag == "cell") {
			hitfriendW = false;
			collision.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			collision.gameObject.tag =("moveeffect");
		}
	}
}
