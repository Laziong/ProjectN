using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GameReseting(){
		Application.LoadLevel ("Start");
	}
}
