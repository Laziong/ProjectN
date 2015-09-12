using UnityEngine;
using System.Collections;

public class CopyObject : MonoBehaviour {

	public GameObject copyobj;

	public GameObject SeSystem;

	public GameObject Copycellobj;

	bool Copy;

	// Use this for initialization
	void Start () {
		Copy = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnManager.Allselect == true && Copy == false) {
			copyobj = SeSystem.gameObject.GetComponent<SelectSystem> ().hitobj;
			Vector3 copypos = new Vector3 (-20.0f, -1.405f, 5.0f);
			Quaternion copyrote = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);

			Copycellobj = Instantiate (copyobj, copypos, copyrote) as GameObject;
			Copycellobj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

			Copy = true;

		}else if(TurnManager.Allselect == false && Copy == true){
			Destroy(Copycellobj);
			Copy = false;
		}
	}
}
