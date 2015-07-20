using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	//行動ポイント
	public static int blackpoint;
	public static int whitepoint;

	//選択管理
	public static bool Allselect;

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

	//コマスクリプト取得用
	//キング
	//クイーン
	//ビショップ
	//アサシン
	//ルーク
	public RookWhite WRook1_script;
	public RookWhite WRook2_script;
	public RookBlack BRook1_script;
	public RookBlack BRook2_script;

	//ポーン

	//テスト用
	/*public GameObject WhiteTest;
	public GameObject BlackTest;
	public test test_script;
	public test2 test2_script;*/

	//public GameObject WhiteTest;
	//public GameObject BlackTest;
	//public test test_script;
	//public test2 test2_script;


	// Use this for initialization
	public void Awake () {
		blackpoint = 1;//初期黒行動ポイント
		whitepoint = 1;//初期白行動ポイント
		turn = 1;//開始ターン
		once = true;
		twice = true;
		Allselect = false;



		//test_script = WhiteTest.GetComponent<test> ();
		//test2_script = BlackTest.GetComponent<test2> ();
		//test_script.enabled = true;
		//test2_script.enabled = true;

		/*test_script = WhiteTest.GetComponent<test> ();
		test2_script = BlackTest.GetComponent<test2> ();
		test_script.enabled = true;
		test2_script.enabled = true;*/

	}
	
	// Update is called once per frame
    public void Update () {
		//順番外でのスクリプト停止と起動
		/*スト用
		if (once == true && twice == true) {
			test_script.enabled = true;
			test2_script.enabled = false;
			twice = false;
			Debug.Log("OK1");
		}
		if (once == false && twice == false) {
			test_script.enabled = false;
			test2_script.enabled = true;
			twice = true;
			Debug.Log ("OK2");
		}*/

		//本番用
		if (once == true && twice == true) {
			WRook1_script.enabled = true;
			WRook2_script.enabled = true;

			BRook1_script.enabled = false;
			BRook2_script.enabled = false;

			twice = false;
		}
		if(once == false && twice == false){
			WRook1_script.enabled = false;
			WRook2_script.enabled = false;

			BRook1_script.enabled = true;
			BRook2_script.enabled = true;

			twice = true;
		}

		//両方０なら行動ポイント１に回復
	if (blackpoint == 0 && whitepoint == 0) {
			blackpoint = 1;
			whitepoint = 1;
			turn++;
		}
	}
}