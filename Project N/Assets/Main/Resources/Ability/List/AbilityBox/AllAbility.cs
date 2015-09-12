using UnityEngine;
using System.Collections;

public class AllAbility : MonoBehaviour {
	
	public string ABname;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AbilityList(){
		switch (this.gameObject.name) {
		case "QueenWhite":
			QueenWhite();
			break;
		}
	}
	
	public void QueenWhite(){
		Debug.Log("testAB");
	}
}
