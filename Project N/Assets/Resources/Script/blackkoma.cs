using UnityEngine;
using System.Collections;

public class blackkoma : MonoBehaviour {
	
	bool select;
	RaycastHit hit;
	Ray ray;
	Renderer rend;
	Color bnColor = Color.black;
	Color noColor = Color.red;
	public GameObject GM;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		int bp = TurnManager.blackpoint;
		if (Input.GetMouseButtonDown (0)) {
			if (bp == 1) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();
			
				if (Physics.Raycast (ray, out hit)) { 
					if (hit.collider.gameObject.name == gameObject.name) {
						//選択状態
						select = !select; 
					}
					//黒コマの場合
					if (gameObject.tag == "bkoma") {
						//選択状態かつtag"cell"なら移動
						if (select && hit.collider.gameObject.tag == "cell") {
							NavMeshAgent agent = GetComponent<NavMeshAgent> ();
							agent.SetDestination (hit.point);
							//非選択状態
							select = false;
							//行動ポイントの消費
							TurnManager.blackpoint -= 1;
						}
						//選択状態：noColor・非選択状態：bnColor
						rend = GetComponent<Renderer> ();
						if (select) {
							rend.material.color = noColor;
						} else {
							rend.material.color = bnColor;
						}
					}
				}
			}
		}
	}
}
