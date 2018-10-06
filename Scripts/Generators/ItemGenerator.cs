using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	private List<string> itemTypes = new List<string>() {"potion"};

	public void GenerateItem() {
		Debug.Log("generating item type");
		string randomType = itemTypes[Random.Range(0, itemTypes.Count)];
		Debug.Log(randomType);
		
		// return randomType;
	}
}
