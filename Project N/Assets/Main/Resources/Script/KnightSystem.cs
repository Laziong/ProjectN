using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class KnightSystem : MonoBehaviour {
	
	public GameObject mv;//移動範囲表示用オブジェクト
	public bool MoveStopCell;//移動範囲マスの表示停止用

	public GameObject SeSystem;//選択システム
 	public GameObject inobj;//自オブジェクト

	public bool belong_white;//ターン管理
	public bool belong_black;//同上
	public bool belong;//一回だけ所属決め

	public GameObject hitpoint;//通常移動時の選択地点

	bool Pawn_twice;//ポーン２マス用


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
		belong = true;
	}
	
	// Update is called once per frame
	void Update () {


		//最初のターン時の所属決め
	if (GetComponent<WhiteTurn> ().enabled == true && belong == true) {
			belong_white = true;
			belong_black = false;
			belong = false;
		}
	if (GetComponent<BlackTurn> ().enabled == true && belong == true) {
			belong_white = false;
			belong_black = true;
			belong = false;
		}

		if (belong_white == true) {
			MoveStopCell = mv.GetComponent<Edestroy> ().hitfriendW;
		} else if
			(belong_black == true) {
			MoveStopCell = mv.GetComponent<Edestroy2>().hitfriendB;
		}
	
	}
	//ここから移動範囲表示用
	//移動範囲表示メソッド呼び出し
	public void Select(){
		inobj = this.gameObject;
		string objtag = this.gameObject.tag;
		switch (objtag) {
		case "King":
			King();
			break;
		case "Queen":
			Queen();
			break;
		case "Bishop":
			Bishop ();
			break;
		case "Assasin":
			Assasin ();
			break;
		case "Rook":
			Rook();
			break;
		case "Pawn":
			Pawn();
			break;
		}
	}

	void Bishop(){
		//選択状態
		TurnManager.Allselect = true;
		//移動範囲表示
		//float posx = SeSystem.GetComponent<SelectSystem>().hitobj.GetComponent<Collider>().gameObject.transform.position.x;
		float posx = inobj.gameObject.transform.position.x;
		float posy = inobj.gameObject.transform.position.y;
		float posz = inobj.gameObject.transform.position.z;
		
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
	void Assasin(){
		//選択状態
		TurnManager.Allselect = true;
		//移動範囲表示
		float posx = inobj.gameObject.transform.position.x;
		float posy = inobj.gameObject.transform.position.y;
		float posz = inobj.gameObject.transform.position.z;
		
		int i = 0, a = 0, b = 0;
		//桂馬の如く
		while (i < 2) {
			Vector3 posa = new Vector3 (posx + 1, posy - 0.07f, posz + 2); //斜め右前
			Vector3 posb = new Vector3 (posx - 1, posy - 0.07f, posz + 2); //斜め左前
			Vector3 posc = new Vector3 (posx + 1, posy - 0.07f, posz - 2); //斜め右後
			Vector3 posd = new Vector3 (posx - 1, posy - 0.07f, posz - 2); //斜め左後
			Vector3 pose = new Vector3 (posx + 2, posy - 0.07f, posz + 1); //斜め右前横
			Vector3 posf = new Vector3 (posx - 2, posy - 0.07f, posz + 1); //斜め左前横
			Vector3 posg = new Vector3 (posx + 2, posy - 0.07f, posz - 1); //斜め右後横
			Vector3 posh = new Vector3 (posx - 2, posy - 0.07f, posz - 1); //斜め左後横
			Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
			Instantiate (mv, posa, rote);//右前
			Instantiate (mv, posb, rote);//左前
			Instantiate (mv, posc, rote);//右後
			Instantiate (mv, posd, rote);//左後
			Instantiate (mv, pose, rote);//右前横
			Instantiate (mv, posf, rote);//左前横
			Instantiate (mv, posg, rote);//右後横
			Instantiate (mv, posh, rote);//左後横
			a++;//縦マス
			b++;//横マス
			i++;//マス数
		}
	}
	void King(){
		//選択状態
		TurnManager.Allselect = true;
		//移動範囲表示
		float posx = inobj.gameObject.transform.position.x;
		float posy = inobj.gameObject.transform.position.y;
		float posz = inobj.gameObject.transform.position.z;
		
		int i = 0, a = 0, b = 0;
		//縦横斜め1マス分移動範囲表示
		while (i<2) {
			Vector3 posa = new Vector3 (posx + a, posy - 0.07f, posz + b); //斜め右前
			Vector3 posb = new Vector3 (posx - a, posy - 0.07f, posz + b); //斜め左前
			Vector3 posc = new Vector3 (posx + a, posy - 0.07f, posz - b); //斜め右後
			Vector3 posd = new Vector3 (posx - a, posy - 0.07f, posz - b); //斜め左後
			Vector3 pose = new Vector3 (posx + a, posy - 0.07f, posz);     //縦＋移動
			Vector3 posf = new Vector3 (posx, posy - 0.07f, posz + b);     //横＋移動
			Vector3 posg = new Vector3 (posx - a, posy - 0.07f, posz);     //縦ー移動
			Vector3 posh = new Vector3 (posx, posy - 0.07f, posz - b);     //横ー移動
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
	void Pawn(){
		//選択状態
		TurnManager.Allselect = true;
		//移動範囲表示
		float posx = inobj.gameObject.transform.position.x;
		float posy = inobj.gameObject.transform.position.y;
		float posz = inobj.gameObject.transform.position.z;
		
		int i = 0, a = 0, b = 0;
		//縦1マス分移動範囲表示
		while (i<1) {
			if (belong_white == true) {
				Vector3 posa = new Vector3 (posx, posy - 0.07f, posz - a - 1);     //縦＋移動
				Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
				Instantiate (mv, posa, rote);//縦＋
				
				a++;//縦マス
				b++;//横マス
				i++;//マス数
			} else if
				(belong_black == true) {
				Vector3 posa = new Vector3 (posx, posy - 0.07f, posz + a + 1);
			
			Quaternion rote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
			Instantiate (mv, posa, rote);//縦＋
			
			a++;//縦マス
			b++;//横マス
			i++;//マス数
			}
		}
	}
	void Queen(){
		//選択状態
		TurnManager.Allselect = true;
		//移動範囲表示
		float posx = inobj.gameObject.transform.position.x;
		float posy = inobj.gameObject.transform.position.y;
		float posz = inobj.gameObject.transform.position.z;
		
		int i = 0, a = 0, b = 0;
		//縦横斜め1マス分移動範囲表示
		while (i<8) {
			Vector3 posa = new Vector3 (posx + a, posy - 0.07f, posz + b); //斜め右前
			Vector3 posb = new Vector3 (posx - a, posy - 0.07f, posz + b); //斜め左前
			Vector3 posc = new Vector3 (posx + a, posy - 0.07f, posz - b); //斜め右後
			Vector3 posd = new Vector3 (posx - a, posy - 0.07f, posz - b); //斜め左後
			Vector3 pose = new Vector3 (posx + a, posy - 0.07f, posz);     //縦＋移動
			Vector3 posf = new Vector3 (posx, posy - 0.07f, posz + b); 	   //横＋移動
			Vector3 posg = new Vector3 (posx - a, posy - 0.07f, posz);     //縦ー移動
			Vector3 posh = new Vector3 (posx, posy - 0.07f, posz - b);     //横ー移動
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
	void Rook(){
	//選択状態
	TurnManager.Allselect = true;
	//移動範囲表示
	float posx = inobj.gameObject.transform.position.x;
	float posy = inobj.gameObject.transform.position.y;
	float posz = inobj.gameObject.transform.position.z;
	
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
	//ここまで移動範囲表示用

	//通常移動メソッド
    public void NormalMove(){
		Ray moveray;
		RaycastHit movehit;

		moveray = Camera.main.ScreenPointToRay (Input.mousePosition);
		movehit = new RaycastHit ();
		
		Physics.Raycast (moveray, out movehit);
		hitpoint = movehit.collider.gameObject;
		
		if (movehit.collider.gameObject.tag == "moveeffect") {
			if (Physics.Raycast (moveray, out movehit)) {
				//選択マスへ移動
				if (this.gameObject.tag == "Assasin") {
					this.transform.position = movehit.transform.position;
					if(belong_white == true){
						Invoke("TurnEndWhite",2.0f);
					}else if 
					(belong_black == true){
						Invoke("TurnEndBlack",2.0f);
					}

					Invoke("Stop",0.2f);
				} else {
					agent.SetDestination (movehit.point);
					//Debug.Log();
					animator.SetFloat ("Speed", 5.0f);
					//行動ポイントの消費
					if(belong_white == true){
					Invoke("TurnEndWhite",2.0f);
					}else if 
						  (belong_black == true){
					Invoke("TurnEndBlack",2.0f);
					}

					Invoke("Stop",0.9f);
				}
			}
		}
	//破壊移動用
		//対象が黒駒、自分が白の時
		if (belong_white == true) {
			if (hitpoint.gameObject.GetComponent<BlackTurn> ().enabled == true) {
				Destroy(hitpoint);
				if (this.gameObject.tag == "Assasin") {
					this.transform.position = movehit.transform.position;
				}else{
					agent.SetDestination(movehit.point);
				}
				Invoke("TurnEndWhite",2.0f);
				Invoke("Stop",0.9f);
			}
		}
		
		//対象が白駒、自分が黒の時
		if (belong_black == true) {
			if (hitpoint.gameObject.GetComponent<WhiteTurn> ().enabled == true) {
				Destroy(hitpoint);
				if (this.gameObject.tag == "Assasin") {
					this.transform.position = movehit.transform.position;
				}else{
					agent.SetDestination(movehit.point);
				}
				Invoke("TurnEndBlack",2.0f);
				Invoke("Stop",0.9f);
			}
		}
	}

	//動作ストップ
	void Stop(){
		animator.SetFloat ("Speed", 0.0f);
	}

	//ターンエンド
	void TurnEndWhite(){
		GetComponent<WhiteTurn> ().twice = true;
		TurnManager.once = false;
		TurnManager.whitepoint = 0;
		TurnManager.Allselect = false;
	}
	void TurnEndBlack(){
		GetComponent<BlackTurn> ().twice = true;
		TurnManager.once = true;
		TurnManager.blackpoint = 0;
		TurnManager.Allselect = false;
	}
	void DeadEndWhite(){
	}
	void DeadEndBlack(){
	}
}
