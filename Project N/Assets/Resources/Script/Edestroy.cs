using UnityEngine;
using System.Collections;

public class Edestroy : MonoBehaviour {
	public GameObject GM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	//移動範囲削除
	void Update () {
	if (TurnManager.whitepoint == 0 && TurnManager.Allselect == false) {
			Destroy (this.gameObject);
		}
}
}
