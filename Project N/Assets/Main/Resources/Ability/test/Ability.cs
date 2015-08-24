using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ability : MonoBehaviour {
	//アビリティテスト用
	public TextAsset Abtext;

	// Use this for initialization
	void Start () {
		//駒ごとに最初の[test]以下の部分を変更
		Abtext = Resources.Load ("Ability/test/test")as TextAsset;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
