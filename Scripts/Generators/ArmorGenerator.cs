using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorGenerator : MonoBehaviour {

	private GameObject playerInventory;
	private GameObject playerEquipped;

	private GameObject objToSpawn;
	private Armor armorSpawned;
	private string randomType;
	private string generatedArmor;

	List<string> armorTypes = new List<string>() {"chestplate", "bracers", "helmet", "boots", "legs"};

	void Start () {
		playerInventory = GameObject.Find("Inventory");
		playerEquipped = GameObject.Find("Equipped");
	}

	public void GenerateArmor() {
		Debug.Log("generating armor");

		randomType = GenerateType();
		generatedArmor = randomType;

		// create generatedArmor game object
		objToSpawn = new GameObject(generatedArmor);
		// move to Inventory
		objToSpawn.transform.parent = playerInventory.transform;
		// add armor script to later set attributes
		objToSpawn.AddComponent<Armor>();
		// change "focus" to the Armor component
		armorSpawned = objToSpawn.GetComponent<Armor>();
		// set name of generated armor
		armorSpawned.armorName = randomType;
		// set type of generated armor
		armorSpawned.armorType = randomType;

		GetBaseStats();
	}

	string GenerateType() {
		Debug.Log("generating armor type");
		string randomType = armorTypes[Random.Range(0, armorTypes.Count)];
		
		return randomType;
	}

	void GetBaseStats() {
		Debug.Log("getting armor base stats");
		Debug.Log("random type chosen is " + randomType);
		if (randomType == "chestplate") {
			BaseChestplate();
		}
		else if (randomType == "bracers") {
			BaseBracers();
		}
		else if (randomType == "helmet") {
			BaseHelmet();
		}
		else if (randomType == "boots") {
			BaseBoots();
		}
		else if (randomType == "legs") {
			BaseLegs();
		}
	}

	void BaseChestplate() {
		Debug.Log("running Base chestplate stats");
		armorSpawned.armorDefense = 10;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void BaseBracers() {
		Debug.Log("running Base bracers stats");
		armorSpawned.armorDefense = 2;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void BaseHelmet() {
		Debug.Log("running Base helmet stats");
		armorSpawned.armorDefense = 5;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void BaseBoots() {
		Debug.Log("running Base boots stats");
		armorSpawned.armorDefense = 5;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void BaseLegs() {
		Debug.Log("running Base legs stats");
		armorSpawned.armorDefense = 8;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}
	
}
