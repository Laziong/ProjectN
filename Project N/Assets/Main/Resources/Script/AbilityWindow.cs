using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityWindow : MonoBehaviour {

	//対応する駒の能力説明テキストをセット
	public TextAsset AbilityText;

	public string ExplainData;
	public GameObject Sesytem;

	public GameObject SelectObj;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		SelectObj = Sesytem.gameObject.GetComponent<SelectSystem> ().hitobj;
		AbilityText = SelectObj.GetComponent<Ability> ().Abtext;
		ExplainData = AbilityText.text;
		GetComponent<Text> ().text = ExplainData;
	}

	public void Ability(){

	}
}
