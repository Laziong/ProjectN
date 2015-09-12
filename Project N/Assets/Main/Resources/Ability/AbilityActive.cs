using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityActive : MonoBehaviour {

	//選択システム
	public GameObject Sesystem;
	//アビリティ読み込み
	public GameObject AbilityBox;

	public Button button;

	public string abilityname;

	// Use this for initialization
	void Start () {
		//アビリティ発動用
		button.onClick.AddListener (AbilityAction);
	}
	
	// Update is called once per frame
	void Update () {
		abilityname = AbilityBox.GetComponent<AbilityWindow> ().ADB_ObjName;
	}

	//アビリティ読み込みメソッド
	public void AbilityAction(){
		//テスト用
		//Debug.Log ("Abilityset");
		//Sesystem.gameObject.GetComponent<SelectSystem> ().hitobj.gameObject.GetComponent<test> ().SendMessage ("AbilityList");

		//本番用
		//AbilityListから名前が同一のアビリティを指定して発動
		Sesystem.gameObject.GetComponent<SelectSystem> ().hitobj.gameObject.GetComponent<AllAbility> ().SendMessage ("AbilityList");
	}
}
