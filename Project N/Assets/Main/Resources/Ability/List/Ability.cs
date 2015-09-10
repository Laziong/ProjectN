using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ability {
	
	//オブジェクト名
	public string ObjectName;
	//アビリティ名
	public string AbilityName;
	//アビリティID
	public int AbilityID;
	//アビリティテキスト
	public TextAsset AbilityText;
	//テキスト変換用
	public string ExplainData;
	
	public Ability(string objname,string name,int id)
	{
		ObjectName = objname;
		AbilityName = name;
		AbilityID = id;
		
		//説明テキストの読み込み
		AbilityText = Resources.Load ("Ability/Explain/" + name)as TextAsset;
		//UI表示用にtxtをstringに変換、格納
		ExplainData = AbilityText.text;
	}
}