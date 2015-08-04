using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class BishopWhite : MonoBehaviour {
	
	bool WBishopselect;
	Ray ray;
	Ray moveray;
	RaycastHit hit;
	RaycastHit movehit;
	public GameObject GM;//TurnManager
	public GameObject mv;//移動範囲表示用プレハブ
	[SerializeField, HideInInspector]
	NavMeshAgent agent;
	[SerializeField, HideInInspector]
	Animator animator;
	[SerializeField, HideInInspector]
	Rigidbody movespeed;
	
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		movespeed = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update (){
		if (TurnManager.whitepoint == 1) {//行動ポイント１
			if (TurnManager.Allselect == false) {//選択状態のオブジェクトなしの時
				if (Input.GetMouseButtonDown (0)) {
					//オブジェクト情報取得
					ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {
						if (hit.collider.gameObject.name == gameObject.name) {
							
							//選択状態
							TurnManager.Allselect = true;
							WBishopselect = true;
							//移動範囲表示
							float posx = hit.collider.gameObject.transform.position.x;
							float posy = hit.collider.gameObject.transform.position.y;
							float posz = hit.collider.gameObject.transform.position.z;
							
							int i = 0, a = 0, b = 0;
							//斜め８マス分移動範囲表示
							while (i<8) {
								Vector3 posa = new Vector3 (posx + a, posy - 0.07f, posz + b); //斜め右前
								Vector3 posb = new Vector3 (posx - a, posy - 0.07f, posz + b); //斜め左前
								Vector3 posc = new Vector3 (posx + a, posy - 0.07f, posz - b); //斜め右後
								Vector3 posd = new Vector3 (posx - a, posy - 0.07f, posz - b); //斜め左後
								Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
								Instantiate (mv, posa, rote);//右前
								Instantiate (mv, posb, rote);//左前
								Instantiate (mv, posc, rote);//右後
								Instantiate (mv, posd, rote);//左後
								a++;//縦マス
								b++;//横マス
								i++;//マス数
							}
						}
					}
				}
			}
		}
		
		//通常移動
		if (TurnManager.Allselect == true) {
			if (WBishopselect == true) {
				if (Input.GetMouseButtonDown (0)) {
					moveray = Camera.main.ScreenPointToRay (Input.mousePosition);
					movehit = new RaycastHit ();
					if (Physics.Raycast (moveray, out movehit)) {
						//選択状態かつtag"moveeffect"なら移動
						if (WBishopselect == true && movehit.collider.gameObject.tag == "moveeffect") {
							agent.SetDestination (movehit.point);
							animator.SetFloat("Speed",5.0f);
							//非選択状態
							WBishopselect = false;
							TurnManager.Allselect = false;
							
							//行動ポイントの消費
							TurnManager.whitepoint = 0;
							TurnManager.once = false;
							Invoke("Stop",0.9f);
						}
						//選択状態かつtag"wkoma"なら移動後接触対象を破壊
						if (WBishopselect == true && movehit.collider.gameObject.tag == "bkoma") {
							agent.SetDestination (movehit.point);
							
							//非選択状態
							WBishopselect = false;
							TurnManager.Allselect = false;
							
							//行動ポイントの消費
							TurnManager.whitepoint = 0;
							TurnManager.once = false;
						}
					}
				}
			}
		}
		//右クリックで選択解除
		if (Input.GetMouseButton (1)) {
			WBishopselect = false;
			TurnManager.Allselect = false;
		}
	}
	void Stop(){
		animator.SetFloat ("Speed", 0.0f);
	}
}
