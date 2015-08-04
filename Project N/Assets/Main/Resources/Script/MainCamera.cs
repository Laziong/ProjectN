using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public GameObject target1;
	
	public float radius = 3.0f;
	public float angle = 0.0f;
	public float count = 0.0f;

	// Use this for initialization
	void Start () {
		target1 = GameObject.Find ("CameraRoll");
	}
	
	// Update is called once per frame
	void Update () {
		count += 0.2f; 
	/*if (Input.GetMouseButtonDown (0)) {
			count = 0.0f;
			if(TurnManager.once == true){
				this.transform.position = new Vector3(-0.2f,3.14f,6.23f);
				this.transform.rotation = Quaternion.Euler(33f,179f,359f);
			}else if(TurnManager.once == false){
				this.transform.position = new Vector3 (0.17f, 3.43f, -6.01f);
				this.transform.rotation = Quaternion.Euler(33f,-1.5f,-1.21f);
			}
		}*/
		if (count >= 100f) {
			Vector3 pos = target1.transform.position;
			transform.LookAt (pos);

			transform.position = new Vector3 (pos.x + Mathf.Cos (angle) * radius, pos.y + 8 - angle, pos.z + Mathf.Sin (angle) * 8);
			angle += 0.001f;
		}
		if(count >= 300f){
			count = 0.0f;
		}
		if (TurnManager.Allselect == true && TurnManager.whitepoint == 1) {
			this.transform.position = new Vector3 (0.42f, 8.0f, 0.15f);
			this.transform.rotation = Quaternion.Euler (90, 180, 0);
		} else if (TurnManager.Allselect == true && TurnManager.blackpoint == 1) {
			this.transform.position = new Vector3 (0.42f, 8.0f, 0.15f);
			this.transform.rotation = Quaternion.Euler (90, 0, 0);
		}
		if (TurnManager.Allselect == false && TurnManager.whitepoint == 1) {
			this.transform.position = new Vector3 (-0.2f, 3.14f, 6.23f);
			this.transform.rotation = Quaternion.Euler (33f, 179f, 359f);
		} else if (TurnManager.Allselect == false && TurnManager.blackpoint == 1) {
			this.transform.position = new Vector3 (0.17f, 3.43f, -6.01f);
			this.transform.rotation = Quaternion.Euler (33f, -1.5f, -1.21f);
		}
		}
	public void UpCamera(){
		this.transform.position = new Vector3 (0.42f, 8.0f, 0.15f);
		this.transform.rotation = Quaternion.Euler (90, 180, 0);
	}
}
