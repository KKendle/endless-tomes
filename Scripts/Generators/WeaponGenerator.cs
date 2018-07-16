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

	public void getWeaponBaseStats() {
		Debug.Log("getting weapon base stats");
	}



	List<string> weaponTypes = new List<string>() {"dagger", "sword", "battleaxe", "staff", "mace", "flail", "spear", "bow", "club", "wand", "book"};
    List<string> weaponElements = new List<string>() {"burning", "frost", "lightning"};
    List<string> weaponAttributeTypes = new List<string>() {"healing", "strength", "intellect", "speed", "dexterity"};
    List<string> weaponAttributeModifiers = new List<string>() {"greater", "lesser"};
    List<string> weaponMaterials = new List<string>() {"bone", "paper", "steel", "wood", "copper", "iron", "dragonhide"};

	public void generateWeapon() {
		resetGenerator();

		randomType = generateType();
		randomElement = generateElement();
		randomAttributeType = generateAttribute();
		randomMaterial = generateMaterial();
		generatedWeapon = randomElement + randomMaterial + " " + randomType + randomAttributeType;

		objToSpawn = new GameObject(generatedWeapon);

		// add Weapon script to newly created game object
		objToSpawn.AddComponent<Weapon>();
		// put the Weapon component (script) in a variable for use
		spawnedWeapon = objToSpawn.GetComponent<Weapon>();
		// set Weapon component variables based on what weapon was just generated
		spawnedWeapon.weaponName = generatedWeapon;
		spawnedWeapon.weaponType = randomType;
		getBaseStats(randomType);
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
		string randomAttributeModifier = weaponAttributeModifiers[Random.Range(0, weaponAttributeModifiers.Count)];
		int hasAttribute = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		int hasModifier = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		string attributeType = "";
		
		if (hasAttribute == 1) {
			if (hasModifier == 1) {
			attributeType = " of " + randomAttributeModifier + " " + randomAttributeType;
			}
			else {
			attributeType = " of "+ randomAttributeType;
			}
		}
		
		return attributeType;
	}

	string generateMaterial() {
		string randomMaterial = weaponMaterials[Random.Range(0, weaponMaterials.Count)];
	
		return randomMaterial;
	}

	void getBaseStats(string weaponType) {
		getWeaponDamageRange(weaponType);
		getWeaponStr(weaponType);
	}

	void getWeaponDamageRange(string weaponType) {
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

	void getWeaponStr(string weaponType) {
		switch (weaponType.ToLower()) {
			case "sword":
				spawnedWeapon.weaponStr = 2;
				break;
			case "dagger":
				spawnedWeapon.weaponStr = 1;
				break;
			case "battleaxe":
				spawnedWeapon.weaponStr = 3;
				break;
			
			default:
				Debug.Log("no weapon equipped");
				break;
		}
	}

	private void resetGenerator() {
		randomElement = "";
		randomMaterial = "";
		randomType = "";
		randomAttributeType = "";
		generatedWeapon = "";
	}
}
