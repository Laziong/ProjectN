using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public GameObject target1;
	
	public float radius = 3.0f;
	public float angle = 0.0f;
	public float count = 0.0f;
	bool change;
	bool Tend;
	int var;
	bool random;

	// Use this for initialization
	void Start () {
		change = false;
	}
	
	// Update is called once per frame
	void Update () {
		count += 0.2f;

		//右クリックでカウントリセットして自陣視点に戻る
		if (Input.GetMouseButtonDown (0)) {
			count = 0.0f;
			//白視点
			if (change == false && TurnManager.once == true) {
				this.transform.position = new Vector3 (-0.3f, 3.14f, 6.9f);
				this.transform.rotation = Quaternion.Euler (33f, 179f, 359f);
			} else if
			//黒視点
				(change == false && TurnManager.once == false) {
				this.transform.position = new Vector3 (0.17f, 3.43f, -6.9f);
				this.transform.rotation = Quaternion.Euler (33f, -1.5f, -1.21f);
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

		//移動完了後カメラの自動切替
		if (TurnManager.once == false && Tend == false) {
			change = false;
			Tend = true;
		} else if
			(TurnManager.once == true && Tend == true) {
			change = false;
			Tend = false;
		}
		if (count <= 100) {
			if (change == false && TurnManager.once == false) {
				this.transform.position = new Vector3 (0.17f, 3.43f, -6.01f);
				this.transform.rotation = Quaternion.Euler (33f, -1.5f, -1.21f);
			} else if
			(change == false && TurnManager.once == true) {
				this.transform.position = new Vector3 (-0.2f, 3.14f, 6.23f);
				this.transform.rotation = Quaternion.Euler (33f, 179f, 359f);
			}
		}
	}

	//対応ボタンクリックで見上げる視点
	public void UpCamera(){
		if (TurnManager.once == true) {
			this.transform.position = new Vector3 (3.0f, 6.4f, 0.15f);
			this.transform.rotation = Quaternion.Euler (90, 180, 0);
			change = true;
		} else if
			(TurnManager.once == false) {
			this.transform.position = new Vector3 (-3.0f, 6.4f, 0.15f);
			this.transform.rotation = Quaternion.Euler (90, 0, 0);
			change = true;
		}
	}

	//対応ボタンクリックで自陣視点
	public void DownCmaera(){
		change = false;
	}
}
