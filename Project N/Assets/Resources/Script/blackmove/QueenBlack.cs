using UnityEngine;
using System.Collections;

public class QueenBlack : MonoBehaviour {
	
	bool select;
	Ray ray;
	Renderer rend;
	Color wnColor = Color.black;
	Color noColor = Color.red;
	public GameObject GM;//TurnManager
	public GameObject mv;//移動範囲表示用プレハブ
	
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update (){
		if (Input.GetMouseButtonDown (0)) {
			if (TurnManager.blackpoint == 1) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();
				
				if (Physics.Raycast (ray, out hit)) { 
					if (hit.collider.gameObject.name == gameObject.name) {
						//選択状態
						select = !select; 
						rend.material.color = noColor;
						//移動範囲表示
						if (select) {
							float posx = hit.collider.gameObject.transform.position.x;
							float posy = hit.collider.gameObject.transform.position.y;
							float posz = hit.collider.gameObject.transform.position.z;
							
							int i = 0, a = 0, b = 0;
							//縦横８マス分移動範囲表示
							while (i<8) {
								Vector3 posa = new Vector3 (posx + a, posy - 0.36f, posz);     //縦＋移動
								Vector3 posb = new Vector3 (posx, posy - 0.36f, posz + b); //横＋移動
								Vector3 posc = new Vector3 (posx - a, posy - 0.36f, posz);     //縦ー移動
								Vector3 posd = new Vector3 (posx, posy - 0.36f, posz - b); //横ー移動
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
					//黒コマの場合
					//通常移動
					if (gameObject.tag == "bkoma") {
						//選択状態かつtag"moveeffect"なら移動
						if (select && hit.collider.gameObject.tag == "moveeffect") {
							NavMeshAgent agent = GetComponent<NavMeshAgent> ();
							agent.SetDestination (hit.point);
							//非選択状態
							select = false;
							rend.material.color = wnColor;
							//行動ポイントの消費
							TurnManager.blackpoint = 0;
							TurnManager.once = true;
							
							Debug.Log(TurnManager.once);
							Debug.Log(TurnManager.blackpoint);
						}
						//選択状態かつtag"wkoma"なら移動後接触対象を破壊
						if (select && hit.collider.gameObject.tag == "wkoma") {
							NavMeshAgent agentenemy = GetComponent<NavMeshAgent> ();
							agentenemy.SetDestination (hit.point);
							//非選択状態
							select = false;
							rend.material.color = wnColor;
							//行動ポイントの消費
							TurnManager.blackpoint = 0;
							TurnManager.once = true;
						}
					}
				}
			}
		}
	}
}
