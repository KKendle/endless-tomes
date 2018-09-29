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

		GetBaseStats(armorSpawned);
	}

	string GenerateType() {
		Debug.Log("generating armor type");
		string randomType = armorTypes[Random.Range(0, armorTypes.Count)];
		
		return randomType;
	}

	public void GetBaseStats(Armor armor) {
		Debug.Log("getting armor base stats");
		Debug.Log("random type chosen is " + armor.armorType);
		if (armor.armorType == "helm") {
			BaseHelm(armor);
		}
		else if (armor.armorType == "shoulders") {
			BaseShoulders(armor);
		}
		else if (armor.armorType == "chestplate") {
			BaseChestplate(armor);
		}
		else if (armor.armorType == "bracers") {
			BaseBracers(armor);
		}
		else if (armor.armorType == "gloves") {
			BaseGloves(armor);
		}
		else if (armor.armorType == "legs") {
			BaseLegs(armor);
		}
		else if (armor.armorType == "boots") {
			BaseBoots(armor);
		}
	}

	void BaseHelm(Armor armor) {
		Debug.Log("running Base helm stats");
		armor.armorDefense = 5;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseShoulders(Armor armor) {
		Debug.Log("running Base shoulders stats");
		armor.armorDefense = 7;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseChestplate(Armor armor) {
		Debug.Log("running Base chestplate stats");
		armor.armorDefense = 10;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseBracers(Armor armor) {
		Debug.Log("running Base bracers stats");
		armor.armorDefense = 2;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseGloves(Armor armor) {
		Debug.Log("running Base gloves stats");
		armor.armorDefense = 3;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseLegs(Armor armor) {
		Debug.Log("running Base legs stats");
		armor.armorDefense = 8;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}

	void BaseBoots(Armor armor) {
		Debug.Log("running Base boots stats");
		armor.armorDefense = 5;
		armor.armorStr = 1;
		armor.armorCon = 1;
		armor.armorDex = 1;
		armor.armorInt = 1;
		armor.armorWis = 1;
		armor.armorHeal = 1;
	}	
}
