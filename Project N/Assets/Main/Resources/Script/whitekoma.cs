using UnityEngine;
using System.Collections;

public class whitekoma : MonoBehaviour {

	bool select;
	RaycastHit hit;
	Ray ray;
	Renderer rend;
	Color wnColor = Color.white;
	Color noColor = Color.red;
	public GameObject GM;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update (){
		int wp = TurnManager.whitepoint;
		if (Input.GetMouseButtonDown (0)) {
			if (wp == 1) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) { 
					if (hit.collider.gameObject.name == gameObject.name) {
						//選択状態
						select = !select; 
					}
					//白コマの場合
					if (gameObject.tag == "wkoma") {
						//選択状態かつtag"cell"なら移動
						if (select && hit.collider.gameObject.tag == "cell") {
							NavMeshAgent agent = GetComponent<NavMeshAgent> ();
							agent.SetDestination (hit.point);
							//非選択状態
							select = false;
							//行動ポイントの消費
							TurnManager.whitepoint -= 1;
						}
						//選択状態：noColor・非選択状態：wnColor
						rend = GetComponent<Renderer> ();
						if (select) {
							rend.material.color = noColor;
						} else {
							rend.material.color = wnColor;
						}
					}
				}
			}
		}
	}
}
	