using UnityEngine;
using System.Collections;

public class BlackTurn : MonoBehaviour {
	
	public GameObject KSystem;
	public bool twice;//ターン管理用
	
	// Use this for initialization
	void Start () {
		KSystem = this.gameObject;
		twice = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.once == true && twice == false) {
			KSystem.GetComponent<KnightSystem>().enabled = false;
			twice = true;
		} else if
		(TurnManager.once == false && twice == true) {

			KSystem.GetComponent<KnightSystem>().enabled  = true; 
			twice = false;
		}
		
	}
}
