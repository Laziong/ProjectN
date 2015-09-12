using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public GameObject target1;

	public bool Tend;
	int var;
	bool random;

	// Use this for initialization
	void Start () {
		Tend = true;
	}
	
	// Update is called once per frame
	void Update () {

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
