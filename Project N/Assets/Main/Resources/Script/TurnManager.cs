using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	//行動ポイント
	public static int blackpoint;
	public static int whitepoint;

	//選択管理
	public static bool Allselect;

	//経過ターン
	//ターン数
	public static int turn;
	//一回実行用
	public static bool once;


	// Use this for initialization
	public void Awake () {
		blackpoint = 1;//初期黒行動ポイント
		whitepoint = 1;//初期白行動ポイント
		turn = 1;//開始ターン
		once = true;
		Allselect = false;

	}
	
	// Update is called once per frame
    public void Update () {
		//両方０なら行動ポイント１に回復
	if (blackpoint == 0 && whitepoint == 0) {
			blackpoint = 1;
			whitepoint = 1;
			turn++;
		}
	}
}