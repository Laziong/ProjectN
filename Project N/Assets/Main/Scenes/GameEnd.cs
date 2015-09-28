using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

	void OnDestroy(){
		Invoke("GameEnding",1.0f);
		}
	void GameEnding(){
		Debug.Log ("Gameend");
		Application.LoadLevel ("End");
	}
}
