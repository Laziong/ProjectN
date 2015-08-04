using UnityEngine;
using System.Collections;

public class Edestroy2 : MonoBehaviour {
	public GameObject GM;
	Renderer Ccolor;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//移動範囲削除
	void Update () {
		if (TurnManager.blackpoint == 0 || TurnManager.Allselect == false) {
			Destroy (this.gameObject);
		}
	}
	void OnCollisionStay(Collision collision){
		if (collision.gameObject.tag == "cell") {
			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			collision.gameObject.tag = ("moveeffect");
		}
	}
}
