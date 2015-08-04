using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class QueenBlack : MonoBehaviour {
	
	bool BBishopselect;
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
		if (TurnManager.blackpoint == 1) {//行動ポイント１
			if (TurnManager.Allselect == false) {//選択状態のオブジェクトなしの時
				if (Input.GetMouseButtonDown (0)) {
					//オブジェクト情報取得
					ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {
						if (hit.collider.gameObject.name == gameObject.name) {
							
							//選択状態
							TurnManager.Allselect = true;
							BBishopselect = true;
							//移動範囲表示
							float posx = hit.collider.gameObject.transform.position.x;
							float posy = hit.collider.gameObject.transform.position.y;
							float posz = hit.collider.gameObject.transform.position.z;
							
							int i = 0, a = 0, b = 0;
							//縦横斜め1マス分移動範囲表示
							while (i<8) {
								Vector3 posa = new Vector3 (posx + a, posy - 0.07f, posz + b); //斜め右前
								Vector3 posb = new Vector3 (posx - a, posy - 0.07f, posz + b); //斜め左前
								Vector3 posc = new Vector3 (posx + a, posy - 0.07f, posz - b); //斜め右後
								Vector3 posd = new Vector3 (posx - a, posy - 0.07f, posz - b); //斜め左後
								Vector3 pose = new Vector3 (posx + a, posy - 0.07f, posz);     //縦＋移動
								Vector3 posf = new Vector3 (posx, posy - 0.07f, posz + b); //横＋移動
								Vector3 posg = new Vector3 (posx - a, posy - 0.07f, posz);     //縦ー移動
								Vector3 posh = new Vector3 (posx, posy - 0.07f, posz - b); //横ー移動
								Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
								Instantiate (mv, posa, rote);//右前
								Instantiate (mv, posb, rote);//左前
								Instantiate (mv, posc, rote);//右後
								Instantiate (mv, posd, rote);//左後
								Instantiate (mv, pose, rote);//縦＋
								Instantiate (mv, posf, rote);//横＋
								Instantiate (mv, posg, rote);//縦ー
								Instantiate (mv, posh, rote);//横ー
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
			if (BBishopselect == true) {
				if (Input.GetMouseButtonDown (0)) {
					moveray = Camera.main.ScreenPointToRay (Input.mousePosition);
					movehit = new RaycastHit ();
					if (Physics.Raycast (moveray, out movehit)) {
						//選択状態かつtag"moveeffect"なら移動
						if (BBishopselect == true && movehit.collider.gameObject.tag == "moveeffect") {
							agent.SetDestination (movehit.point);
							animator.SetFloat("Speed",5.0f);
							//非選択状態
							BBishopselect = false;
							TurnManager.Allselect = false;
							
							//行動ポイントの消費
							TurnManager.blackpoint = 0;
							TurnManager.once = true;
							Invoke("Stop",0.9f);
						}
						//選択状態かつtag"wkoma"なら移動後接触対象を破壊
						if (BBishopselect == true && movehit.collider.gameObject.tag == "wkoma") {
							agent.SetDestination (movehit.point);
							
							//非選択状態
							BBishopselect = false;
							TurnManager.Allselect = false;
							
							//行動ポイントの消費
							TurnManager.blackpoint = 0;
							TurnManager.once = true;
						}
					}
				}
			}
		}
		//右クリックで選択解除
		if (Input.GetMouseButton (1)) {
			BBishopselect = false;
			TurnManager.Allselect = false;
		}
	}
	void Stop(){
		animator.SetFloat ("Speed", 0.0f);
	}
}
