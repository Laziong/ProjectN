using UnityEngine;
using System.Collections;

public class WhiteTurn : MonoBehaviour {

	public GameObject KSystem;
	public bool twice;//ターン管理用

	// Use this for initialization
	void Start () {
		KSystem = this.gameObject;
		twice = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.once == true && twice == true) {
			KSystem.GetComponent<KnightSystem>().enabled = true;
			twice = false;
		} else if
			(TurnManager.once == false && twice == false) {
			KSystem.GetComponent<KnightSystem>().enabled = false;
			twice = true;
		}
	
	}
}
