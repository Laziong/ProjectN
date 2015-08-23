using UnityEngine;
using System.Collections;

public class SelectSystem : MonoBehaviour {
	public Ray ray;
	public Ray moveray;

	public RaycastHit hit;

	public GameObject hitobj;

	public bool inselect;

	// Use this for initialization
	void Start () {
		inselect = false;

	}
	
	// Update is called once per frame
 public	void Update () {
		///白ターンの時
		if(TurnManager.once == true){
		//ユニット選択状態の時
		if (Input.GetMouseButtonDown (0)) {
			if (TurnManager.Allselect == true) {
				//移動メソッド呼び出し
					if(hitobj.GetComponent<WhiteTurn>().enabled == true){
				hitobj.SendMessage ("NormalMove");
					}

		//非選択状態の時
			}else if (TurnManager.Allselect == false) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				hit = new RaycastHit ();
				Physics.Raycast (ray, out hit);
				hitobj = hit.collider.gameObject;

				if (Physics.Raycast (ray, out hit)) {
						if(hitobj.GetComponent<WhiteTurn>().enabled == true){
				//移動範囲表示メソッド呼び出し
				hitobj.SendMessage ("Select");
						}
					}
				}
			}
		}
		///黒ターンの時
		if(TurnManager.once == false){
			//ユニット選択状態の時
			if (Input.GetMouseButtonDown (0)) {
				if (TurnManager.Allselect == true) {
					//移動メソッド呼び出し
					if(hitobj.GetComponent<BlackTurn>().enabled == true){
						hitobj.SendMessage ("NormalMove");
					}
					
					//非選択状態の時
				}else if (TurnManager.Allselect == false) {
					ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					hit = new RaycastHit ();
					Physics.Raycast (ray, out hit);
					hitobj = hit.collider.gameObject;
					
					if (Physics.Raycast (ray, out hit)) {
						if(hitobj.GetComponent<BlackTurn>().enabled == true){
							//移動範囲表示メソッド呼び出し
							hitobj.SendMessage ("Select");
						}
					}
				}
			}
		}
					if (Input.GetMouseButtonDown (1)) {
						TurnManager.Allselect = false;
		}
	}
}

