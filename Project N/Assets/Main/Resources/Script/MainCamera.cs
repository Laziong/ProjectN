using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public GameObject target1;
	
	public float radius = 3.0f;
	public float angle = 0.0f;
	public float count = 0.0f;
	//bool change;
	public bool Tend;
	int var;
	bool random;

	// Use this for initialization
	void Start () {
		//change = false;
		Tend = true;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		count += 0.2f;

		//右クリックでカウントリセットして自陣視点に戻る
		if (Input.GetMouseButtonDown (1)) {
			count = 0.0f;
			//白視点
			if (change == false && TurnManager.once == true) {
				this.transform.position = new Vector3 (4.2f, 40.0f, 0);
				this.transform.rotation = Quaternion.Euler (90, 180, 0);
			} else if
			//黒視点
				(change == false && TurnManager.once == false) {
				this.transform.position = new Vector3 (-4.2f, 40.0f, 0f);
				this.transform.rotation = Quaternion.Euler (90, 0, 0);
			}
		}

		//カウント100以上でカメラ自動旋回
		if (random == false) {
			var = Random.Range (0, 15);
			random = true;
		}
		if (count >= 100f) {
			switch(var){
			case 0:
				target1 = GameObject.Find("kingBlack");
				break;
			case 1:
				target1 = GameObject.Find("kingWhite");
				break;
			case 2:
				target1 = GameObject.Find("QueenBlack");
				break;
			case 3:
				target1 = GameObject.Find("QueenWhite");
				break;
			case 4:
				target1 = GameObject.Find("RookBlack");
				break;
			case 5:
				target1 = GameObject.Find("RookWhite");
				break;
			case 6:
				target1 = GameObject.Find("BishopBlack");
				break;
			case 7:
				target1 = GameObject.Find("BishopWhite");
				break;
			case 8:
				target1 = GameObject.Find("RookBlack2");
				break;
			case 9:
				target1 = GameObject.Find("RookWhite");
				break;
			case 10:
				target1 = GameObject.Find("BishopBlack");
				break;
			case 11:
				target1 = GameObject.Find("BishopWhite");
				break;
			case 12:
				target1 = GameObject.Find("AssasinBlack");
				break;
			case 13:
				target1 = GameObject.Find("AssasinBlack2");
				break;
			case 14:
				target1 = GameObject.Find("AssasinWhite");
				break;
			case 15:
				target1 = GameObject.Find("AssasinWhite2");
				break;
			}

			Vector3 pos = target1.transform.position;
			transform.LookAt (pos);

			transform.position = new Vector3 (pos.x + Mathf.Cos (angle) * radius, pos.y + 3 - angle, pos.z + Mathf.Sin (angle) * 8);
			angle += 0.001f;
		}
		//カウント300で0に戻る
		if (count >= 300f) {
			count = 0.0f;
			random =false;
		}
		*/

		//移動完了後カメラの自動切替
		//白視点
		if (Tend == true && TurnManager.once == true) {
			this.transform.position = new Vector3 (4.2f, 40.0f, 0);
			this.transform.rotation = Quaternion.Euler (90, 180, 0);
			Tend = false;
		} else if
			//黒視点
		(Tend == false && TurnManager.once == false) {
			this.transform.position = new Vector3 (-4.2f, 40.0f, 0f);
			this.transform.rotation = Quaternion.Euler (90, 0, 0);
			Tend = true;
		}
	}
}
