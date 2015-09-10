using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AbilityWindow : MonoBehaviour {

	/// <summary>
	/// データベースから名前で対応アビリティを参照
	/// </summary>

	//対応する駒の能力説明テキストをセット
	public GameObject Sesystem;
	//選択中のオブジェクト名
	public string SelectObjName;

	//データベース参照
	public AbilityDataBase database;
	public int i;

	public string ADB_ObjName;
	public string ADB_AbilityName;
	public int ADB_Ability_ID;
	public TextAsset ADB_AbilityText;
	public string ADB_ExplainData;


	// Use this for initialization
	void Start () {
		i = 0;
	}

	// Update is called once per frame
	void Update () {
		SelectObjName = Sesystem.gameObject.GetComponent<SelectSystem> ().hitobj.gameObject.name;

		if (TurnManager.Allselect == true) {
			for (i = 0; ADB_ObjName != SelectObjName; ++i) {
				ADB_ObjName = database.ability [i].ObjectName;
				ADB_AbilityName = database.ability [i].AbilityName;
				ADB_Ability_ID = database.ability [i].AbilityID;
				ADB_AbilityText = database.ability [i].AbilityText;
				ADB_ExplainData = database.ability [i].ExplainData;
			}
			GetComponent<Text> ().text = ADB_ExplainData;
		} else {
			i = 0;
			GetComponent<Text>().text = " ";
		}
	}
}
