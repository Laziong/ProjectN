using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class RookWhite : MonoBehaviour {
	
	bool WRookselect;
	Ray ray;
	Ray moveray;
	RaycastHit hit;
	RaycastHit movehit;
	Renderer rend;
	Color wnColor = Color.white;
	Color noColor = Color.red;
	public GameObject GM;//TurnManager
	public GameObject mv;//移動範囲表示用プレハブ
	[SerializeField, HideInInspector] Animator animator;
	
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		//rend = GetComponent<Renderer> ();
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
							//rend.material.color = noColor;
							TurnManager.Allselect = true;
							WRookselect = true;
							
							//移動範囲表示
							float posx = hit.collider.gameObject.transform.position.x;
							float posy = hit.collider.gameObject.transform.position.y;
							float posz = hit.collider.gameObject.transform.position.z;
							
							int i = 0, a = 0, b = 0;
							//縦横８マス分移動範囲表示
							while (i<8) {
								Vector3 posa = new Vector3 (posx + a, posy - 0.07f, posz);     //縦＋移動
								Vector3 posb = new Vector3 (posx, posy - 0.07f, posz + b); //横＋移動
								Vector3 posc = new Vector3 (posx - a, posy - 0.07f, posz);     //縦ー移動
								Vector3 posd = new Vector3 (posx, posy - 0.07f, posz - b); //横ー移動
								Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
								Instantiate (mv, posa, rote);//縦＋
								Instantiate (mv, posb, rote);//横＋
								Instantiate (mv, posc, rote);//縦ー
								Instantiate (mv, posd, rote);//横ー
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
			if (WRookselect == true) {
				if (Input.GetMouseButtonDown (0)) {
					moveray = Camera.main.ScreenPointToRay (Input.mousePosition);
					movehit = new RaycastHit ();
					if (Physics.Raycast (moveray, out movehit)) {
						//選択状態かつtag"moveeffect"なら移動
						if (WRookselect == true && movehit.collider.gameObject.tag == "moveeffect") {
							NavMeshAgent agent = GetComponent<NavMeshAgent> ();
							agent.SetDestination (movehit.point);
							animator.SetFloat("Speed",agent.velocity.sqrMagnitude);
							//非選択状態
							WRookselect = false;
							TurnManager.Allselect = false;
							//rend.material.color = wnColor;
							//行動ポイントの消費
							TurnManager.whitepoint = 0;
							TurnManager.once = true;
							
							Debug.Log (TurnManager.once);
							Debug.Log (TurnManager.whitepoint);
						}
						//選択状態かつtag"wkoma"なら移動後接触対象を破壊
						if (WRookselect == true && movehit.collider.gameObject.tag == "bkoma") {
							NavMeshAgent agentenemy = GetComponent<NavMeshAgent> ();
							agentenemy.SetDestination (movehit.point);
							//非選択状態
							WRookselect = false;
							TurnManager.Allselect = false;
							//rend.material.color = wnColor;
							//行動ポイントの消費
							TurnManager.whitepoint = 0;
							TurnManager.once = true;
						}
					}
				}
			}
		}
		//右クリックで選択解除
		if (Input.GetMouseButton (1)) {
			WRookselect = false;
			TurnManager.Allselect = false;
			//rend.material.color = wnColor;
		}
	}
}
