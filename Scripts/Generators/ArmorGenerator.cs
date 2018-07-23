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

	public void generateArmor() {
		Debug.Log("generating armor");

		randomType = generateType();
		generatedArmor = randomType;

		// create generatedArmor game object
		objToSpawn = new GameObject(generatedArmor);
		// add armor script to later set attributes
		objToSpawn.AddComponent<Armor>();
		// change "focus" to the Armor component
		armorSpawned = objToSpawn.GetComponent<Armor>();
		// set name of generated armor
		armorSpawned.armorName = randomType;
		// set type of generated armor
		armorSpawned.armorType = randomType;

		getBaseStats();
	}

	string generateType() {
		Debug.Log("generating armor type");
		string randomType = armorTypes[Random.Range(0, armorTypes.Count)];
		
		return randomType;
	}

	void getBaseStats() {
		Debug.Log("getting armor base stats");
		Debug.Log("random type chosen is " + randomType);
		if (randomType == "chestplate") {
			baseChestplate();
		}
		else if (randomType == "bracers") {
			baseBracers();
		}
		else if (randomType == "helmet") {
			baseHelmet();
		}
		else if (randomType == "boots") {
			baseBoots();
		}
		else if (randomType == "legs") {
			baseLegs();
		}
	}

	void baseChestplate() {
		Debug.Log("running base chestplate stats");
		armorSpawned.armorDefense = 1;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void baseBracers() {
		Debug.Log("running base bracers stats");
		armorSpawned.armorDefense = 1;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void baseHelmet() {
		Debug.Log("running base helmet stats");
		armorSpawned.armorDefense = 1;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void baseBoots() {
		Debug.Log("running base boots stats");
		armorSpawned.armorDefense = 1;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}

	void baseLegs() {
		Debug.Log("running base legs stats");
		armorSpawned.armorDefense = 1;
		armorSpawned.armorStr = 1;
		armorSpawned.armorCon = 1;
		armorSpawned.armorDex = 1;
		armorSpawned.armorInt = 1;
		armorSpawned.armorWis = 1;
		armorSpawned.armorHeal = 1;
	}
	
}
