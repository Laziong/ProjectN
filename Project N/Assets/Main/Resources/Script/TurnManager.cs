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

	//コマスクリプト取得用//駒種と数毎に追加
	//キング
	public KingWhite WKing_script;
	public KingBlack BKing_script;
	//クイーン
	public QueenWhite WQueen_script;
	public QueenBlack BQueen_script;
	//ビショップ
	public BishopWhite WBishop1_script;
	public BishopWhite WBishop2_script;
	public BishopBlack BBishop1_script;
	public BishopBlack BBishop2_script;

	//アサシン
	public AssasinWhite WAssa1_script;
	public AssasinWhite WAssa2_script;

	public AssasinBlack BAssa1_script;
	public AssasinBlack BAssa2_script;

	//ルーク
	public RookWhite WRook1_script;
	public RookWhite WRook2_script;
	public RookBlack BRook1_script;
	public RookBlack BRook2_script;

	//ポーン
	public PawnWhite WPawn1_script;
	public PawnWhite WPawn2_script;
	public PawnWhite WPawn3_script;
	public PawnWhite WPawn4_script;
	public PawnWhite WPawn5_script;
	public PawnWhite WPawn6_script;
	public PawnWhite WPawn7_script;
	public PawnWhite WPawn8_script;

	public PawnBlack BPawn1_script;
	public PawnBlack BPawn2_script;
	public PawnBlack BPawn3_script;
	public PawnBlack BPawn4_script;
	public PawnBlack BPawn5_script;
	public PawnBlack BPawn6_script;
	public PawnBlack BPawn7_script;
	public PawnBlack BPawn8_script;

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
			//白
			//ルーク
			WRook1_script.enabled = true;
			WRook2_script.enabled = true;
			//ビショップ
			WBishop1_script.enabled = true;
			WBishop2_script.enabled = true;
			//アサシン
			WAssa1_script.enabled = true;
			WAssa2_script.enabled = true;
			//キングとクイーン
			WKing_script.enabled = true;
			WQueen_script.enabled = true;
			//ポーン
			WPawn1_script.enabled = true;
			WPawn2_script.enabled = true;
			WPawn3_script.enabled = true;
			WPawn4_script.enabled = true;
			WPawn5_script.enabled = true;
			WPawn6_script.enabled = true;
			WPawn7_script.enabled = true;
			WPawn8_script.enabled = true;

			//黒
			//ルーク
			BRook1_script.enabled = false;
			BRook2_script.enabled = false;
			//ビショップ
			BBishop1_script.enabled = false;
			BBishop2_script.enabled = false;
			//アサシン
			BAssa1_script.enabled = false;
			BAssa2_script.enabled = false;
			//キングとクイーン
			BKing_script.enabled = false;
			BQueen_script.enabled = false;
			//ポーン
			BPawn1_script.enabled = false;
			BPawn2_script.enabled = false;
			BPawn3_script.enabled = false;
			BPawn4_script.enabled = false;
			BPawn5_script.enabled = false;
			BPawn6_script.enabled = false;
			BPawn7_script.enabled = false;
			BPawn8_script.enabled = false;

			twice = false;
		}
		if(once == false && twice == false){
			//白
			//ルーク
			WRook1_script.enabled = false;
			WRook2_script.enabled = false;
			//ビショップ
			WBishop1_script.enabled = false;
			WBishop2_script.enabled = false;
			//アサシン
			WAssa1_script.enabled = false;
			WAssa2_script.enabled = false;
			//キングとクイーン
			WKing_script.enabled = false;
			WQueen_script.enabled = false;
			//ポーン
			WPawn1_script.enabled = false;
			WPawn2_script.enabled = false;
			WPawn3_script.enabled = false;
			WPawn4_script.enabled = false;
			WPawn5_script.enabled = false;
			WPawn6_script.enabled = false;
			WPawn7_script.enabled = false;
			WPawn8_script.enabled = false;

			//黒
			//ルーク
			BRook1_script.enabled = true;
			BRook2_script.enabled = true;
			//ビショップ
			BBishop1_script.enabled = true;
			BBishop2_script.enabled = true;
			//アサシン
			BAssa1_script.enabled = true;
			BAssa2_script.enabled = true;
			//キングとクイーン
			BKing_script.enabled = true;
			BQueen_script.enabled = true;
			//ポーン
			BPawn1_script.enabled = true;
			BPawn2_script.enabled = true;
			BPawn3_script.enabled = true;
			BPawn4_script.enabled = true;
			BPawn5_script.enabled = true;
			BPawn6_script.enabled = true;
			BPawn7_script.enabled = true;
			BPawn8_script.enabled = true;

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