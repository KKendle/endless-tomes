using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

	GameObject objToSpawn;

	public void enemyDrops() {
        Debug.Log("checking for enemy drops");
		objToSpawn = new GameObject(generateWeapon());
		Debug.Log("spawning weapon: " + objToSpawn);
    }



	List<string> weaponTypes = new List<string>() {"dagger", "sword", "battleaxe", "staff", "mace", "flail", "spear", "bow", "club", "wand", "book"};
    List<string> weaponElements = new List<string>() {"burning", "frost", "lightning"};
    List<string> weaponAttributes = new List<string>() {"healing", "strength", "intellect", "speed", "dexterity"};
    List<string> weaponAttributeModifiers = new List<string>() {"greater", "lesser"};
    List<string> weaponMaterials = new List<string>() {"bone", "paper", "steel", "wood", "copper", "iron", "dragonhide"};

	string generateWeapon() {
		string randomType = generateType();
		Debug.Log("random type is: " + randomType);

		string randomElement = generateElement();
		Debug.Log("random element is: " + randomElement);

		string randomAttribute = generateAttribute();
		Debug.Log("random attribute is: " + randomAttribute);

		string randomMaterial = generateMaterial();
		Debug.Log("random material is: " + randomMaterial);

		string generatedWeapon = randomElement + randomMaterial + " " + randomType + randomAttribute;
		Debug.Log("generated weapon is: " + generatedWeapon);

		return generatedWeapon;
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
		string randomAttribute = weaponAttributes[Random.Range(0, weaponAttributes.Count)];
		string randomAttributeModifier = weaponAttributeModifiers[Random.Range(0, weaponAttributeModifiers.Count)];
		int hasAttribute = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		int hasModifier = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		string attribute = "";
		
		if (hasAttribute == 1) {
			if (hasModifier == 1) {
			attribute = " of " + randomAttributeModifier + " " + randomAttribute;
			}
			else {
			attribute = " of "+ randomAttribute;
			}
		}
		
		return attribute;
	}

	string generateMaterial() {
		string randomMaterial = weaponMaterials[Random.Range(0, weaponMaterials.Count)];
	
		return randomMaterial;
	}
}
