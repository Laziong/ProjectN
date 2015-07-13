using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	public static int blackpoint;
	public static int whitepoint;
	public static int turn;//経過ターン
	bool once;
	public GameObject test;
	public GameObject bkoma;

	// Use this for initialization
	public void Start () {
		blackpoint = 1;//初期黒行動ポイント
		whitepoint = 1;//初期白行動ポイント
		turn = 1;//開始ターン
	}
	
	// Update is called once per frame
    public void Update () {
		/*if (whitepoint == 1 && blackpoint == 0) {
			GetComponent<test> ().enabled = true;
			once = true;
		} if(whitepoint == 0 && blackpoint == 1 && once == true) {
			GetComponent<test>().enabled = false;
			once = false;
		}
		if (blackpoint == 1 && whitepoint == 0 && once == false) {
			GetComponent<blackkoma> ().enabled = true;
			once = true;
		} if(blackpoint == 0 && blackpoint == 1 && once == true) {
			GetComponent<blackkoma>().enabled = false;
			once = false;
		}*/
		//両方０なら行動ポイント１に回復
	if (blackpoint == 0 && whitepoint == 0) {
			blackpoint = 1;
			whitepoint = 1;
			turn++;
		}
	}
}