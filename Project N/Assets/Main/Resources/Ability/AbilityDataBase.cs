using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityDataBase : MonoBehaviour {

	public List<Ability> ability = new List<Ability>();

	void Start(){
		//アビリティ毎に追記
		//追加例：ability.Add(new Ability ("名前","アビリティ名","ID"));

		//テスト用
		ability.Add (new Ability ("QueenWhite", "test", 999999));
		ability.Add (new Ability ("kingWhite", "test2", 123456));

		//本番用
	}
}