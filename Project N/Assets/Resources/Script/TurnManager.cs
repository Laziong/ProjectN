using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	//行動ポイント
	public static int blackpoint;
	public static int whitepoint;
	//経過ターン
	public static int turn;
	public static bool once;
	public bool twice;
	//コマ管理
	public GameObject WhiteKing;
	public GameObject WhiteQueen;
	public GameObject WhiteBishop;
	public GameObject WhiteAssasin;
	public GameObject WhiteRook;
	public GameObject WhitePawn;
	public GameObject BlackKing;
	public GameObject BlackQueen;
	public GameObject BlackBishop;
	public GameObject BlackAssasin;
	public GameObject BlackRook;
	public GameObject BlackPawn;
	//テスト用
	public GameObject WhiteTest;
	public GameObject BlackTest;
	test test_script;
	test2 test2_script;


	// Use this for initialization
	public void Awake () {
		blackpoint = 1;//初期黒行動ポイント
		whitepoint = 1;//初期白行動ポイント
		turn = 1;//開始ターン
		once = true;
		twice = true;

		test_script = WhiteTest.GetComponent<test> ();
		test2_script = BlackTest.GetComponent<test2> ();

		Debug.Log (once);
		Debug.Log (whitepoint);
		Debug.Log (blackpoint);
	}
	
	// Update is called once per frame
    public void Update () {
		//順番外でのスクリプト停止と起動
		//白コマテスト用
		if (once == true && twice == true) {
			test_script.enabled = true;
			twice = false;
			Debug.Log("OK1");
		}
		if (once == false && twice == true) {
			test_script.enabled = false;
			twice = false;
			Debug.Log ("OK2");
		}
		//黒コマテスト用
		if (once == false && twice == false) {
			test2_script.enabled = true;
			twice = true;
			Debug.Log ("OK3");
		}
		if (once == true && twice == false) {
			test2_script.enabled = false;
			twice = true;
			Debug.Log ("OK4");
		}
		//両方０なら行動ポイント１に回復
	if (blackpoint == 0 && whitepoint == 0) {
			blackpoint = 1;
			whitepoint = 1;
			turn++;
			Debug.Log (whitepoint);
			Debug.Log (blackpoint);
		}
	}
}