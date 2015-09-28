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
		Debug.Log ("testAB");
		if (ABManager.WhiteABP <= 4 || ABManager.BlackABP <= 4) {
			Debug.Log ("testFalse");
		} else if (TurnManager.once == true) {
			TurnManager.WhiteABCount -= 1;
			ABManager.WhiteABP -= 5;
		} else if (TurnManager.once == false) {
			TurnManager.BlackABCount -= 1;
			ABManager.BlackABP -= 5;
		}
	}
}
