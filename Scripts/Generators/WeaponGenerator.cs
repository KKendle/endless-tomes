using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour {

	private GameObject objToSpawn;
	private Weapon spawnedWeapon;
	private string randomElement;
	private string randomMaterial;
	private string randomType;
	private string randomAttributeType;
	private string generatedWeapon;

	public void getBaseStats() {
		Debug.Log("getting weapon base stats");
		getWeaponDamageRange(randomType);
		getWeaponStr(randomType, randomAttributeType);
		getWeaponCon(randomType, randomAttributeType);
	}



	List<string> weaponTypes = new List<string>() {"dagger", "sword", "battleaxe", "staff", "mace", "flail", "spear", "bow", "club", "wand", "book"};
    List<string> weaponElements = new List<string>() {"burning", "frost", "lightning"};
    List<string> weaponAttributeTypes = new List<string>() {"healing", "strength", "intellect", "speed", "dexterity", "constitution"};
    List<string> weaponMaterials = new List<string>() {"bone", "paper", "steel", "wood", "copper", "iron", "dragonhide"};

	public void generateWeapon() {
		resetGenerator();

		randomType = generateType();
		randomElement = generateElement();
		randomAttributeType = generateAttribute();
		randomMaterial = generateMaterial();
		generatedWeapon = randomElement + randomMaterial + " " + randomType + randomAttributeType;

		Debug.Log("after reset and after elements have been declared");
		Debug.Log("get Random Type is " + randomType);
		Debug.Log("get Random Element is " + randomElement);
		Debug.Log("get Random Attribute Type is " + randomAttributeType);
		Debug.Log("get Random Material is " + randomMaterial);
		Debug.Log("generated weapon is " + generatedWeapon);

		objToSpawn = new GameObject(generatedWeapon);

		// add Weapon script to newly created game object
		objToSpawn.AddComponent<Weapon>();
		// put the Weapon component (script) in a variable for use
		spawnedWeapon = objToSpawn.GetComponent<Weapon>();
		// set Weapon component variables based on what weapon was just generated
		spawnedWeapon.weaponName = generatedWeapon;
		spawnedWeapon.weaponType = randomType;
		getBaseStats();
	}

	void getWeaponDamageRange(string weaponType) {
		Debug.Log("running getWeaponDamageRange");
		Debug.Log("weapontype generated is " + weaponType);
		switch (weaponType.ToLower()) {
			case "sword":
				spawnedWeapon.weaponDamageMin = 10.0f;
				spawnedWeapon.weaponDamageMax = 12.0f;
				break;
			case "dagger":
				spawnedWeapon.weaponDamageMin = 6.0f;
				spawnedWeapon.weaponDamageMax = 8.0f;
				break;
			case "battleaxe":
				spawnedWeapon.weaponDamageMin = 12.0f;
				spawnedWeapon.weaponDamageMax = 15.0f;
				break;
			
			default:
				Debug.Log("no weapon equipped");
				break;
		}
	}

	void getWeaponStr(string weaponType, string weaponAttributeType) {
		bool isStrength = false;
		int baseStr = 2;
		float strengthModifier = 2.0f;

		if (weaponAttributeType.ToLower() == " of strength") {
			isStrength = true;
			Debug.Log("is str type attribute");
		}

		foreach(string wepType in weaponTypes) {
			if (weaponType == wepType) {
				Debug.Log("weapon types match");
				if (isStrength) {
					Debug.Log("strength");
					spawnedWeapon.weaponStr = Mathf.RoundToInt(baseStr * strengthModifier);
				}
				else {
					Debug.Log("base");
					spawnedWeapon.weaponStr = Mathf.RoundToInt(baseStr);
				}
				break;
			}
			else {
				Debug.Log("weapon types do not match");
			}
		}
	}

	void getWeaponCon(string weaponType, string weaponAttributeType) {
		bool isConstitution = false;
		int baseCon = 3;
		float constitutionModifier = 2.0f;

		if (weaponAttributeType.ToLower() == " of constitution") {
			isConstitution = true;
			Debug.Log("is con type attribute");
		}

		foreach(string wepType in weaponTypes) {
			if (weaponType == wepType) {
				Debug.Log("weapon types match");
				if (isConstitution) {
					Debug.Log("constitution");
					spawnedWeapon.weaponCon = Mathf.RoundToInt(baseCon * constitutionModifier);
				}
				else {
					Debug.Log("base");
					spawnedWeapon.weaponCon = Mathf.RoundToInt(baseCon);
				}
				break;
			}
			else {
				Debug.Log("weapon types do not match");
			}
		}
	}

	string generateType() {
		string randomType = weaponTypes[Random.Range(0, weaponTypes.Count)];
		
		return randomType;
	}

	string generateElement() {
		string randomElement = weaponElements[Random.Range(0, weaponElements.Count)];
		// floats for inclusive max number
		int hasModifier = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		string element = "";
		
		if (hasModifier == 1) {
			element = randomElement;
			// add space at end for better naming flow without this attribute
			// (only add the space if this attribute is there)
			element += " ";
		}
		
		return element;
	}

	string generateAttribute() {
		string randomAttributeType = weaponAttributeTypes[Random.Range(0, weaponAttributeTypes.Count)];
		int hasAttribute = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		string attributeType = "";
		
		if (hasAttribute == 1) {
			attributeType = " of "+ randomAttributeType;
		}
		
		return attributeType;
	}

	string generateMaterial() {
		string randomMaterial = weaponMaterials[Random.Range(0, weaponMaterials.Count)];
	
		return randomMaterial;
	}

	private void resetGenerator() {
		randomElement = "";
		randomMaterial = "";
		randomType = "";
		randomAttributeType = "";
		generatedWeapon = "";
	}
}
