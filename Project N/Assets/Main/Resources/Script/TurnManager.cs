using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

	//行動ポイント
	public static int blackpoint;
	public static int whitepoint;

	//アビリティ仕様可能回数
	public static int WhiteABCount;
	public static int BlackABCount;

	//選択管理
	public static bool Allselect;

	//経過ターン
	//ターン数
	public static int turn;
	//Trueなら白ターン：Falseで黒ターン
	public static bool once;


	// Use this for initialization
	public void Awake () {
		blackpoint = 1;//初期黒行動ポイント
		whitepoint = 1;//初期白行動ポイント
		turn = 1;//開始ターン

		WhiteABCount = 1;
		BlackABCount = 1;

		once = true;
		Allselect = false;

		this.GetComponent<Text> ().text = "ターン：" + turn.ToString ();
	}

	void Start(){

	}
	
	// Update is called once per frame
    public void Update () {

		//両方０なら行動ポイント１に回復
	if (blackpoint == 0 && whitepoint == 0) {
			blackpoint = 1;
			whitepoint = 1;


			ABManager.WhiteABP += 10;
			ABManager.BlackABP += 10;

			turn++;
			this.GetComponent<Text> ().text = "ターン：" + turn.ToString ();
		}
	}
}