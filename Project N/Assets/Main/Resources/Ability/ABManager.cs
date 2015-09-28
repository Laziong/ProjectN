using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ABManager : MonoBehaviour {


	//アビリティポイント
	public int nowABP;
	
	public static int WhiteABP;
	public static int BlackABP;

	// Use this for initialization
	void Awake () {
		WhiteABP = 50;
		BlackABP = 50;

		this.GetComponent<Text> ().text = "アビリティポイント：" + nowABP.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.once == true) {
			nowABP = WhiteABP;
		} else {
			nowABP = BlackABP;
		}
		this.GetComponent<Text> ().text = "アビリティポイント：" + nowABP.ToString ();
	}
}
