using UnityEngine;
using System.Collections;

public class NearCamera : MonoBehaviour {

	public GameObject Sesystem;

	public GameObject targetobj;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (TurnManager.Allselect == false) {
			this.GetComponent<Camera>().enabled = false;
		}else{
			this.GetComponent<Camera>().enabled = true;
		}
		/*
		targetobj = Sesystem.gameObject.GetComponent<SelectSystem>().hitobj;
		Vector3 pos = targetobj.transform.position;


		if (TurnManager.once == true) {
			this.transform.position = new Vector3 (pos.x, pos.y + 0.7f, pos.z - 2);
			Quaternion roteC = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		} else if
			(TurnManager.once == false) {
			this.transform.position = new Vector3 (pos.x, pos.y + 0.7f, pos.z + 2);
			this.transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
		}
		*/
	}
}
