using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGenerator : MonoBehaviour {

	private GameObject weaponPrefab;
	private Weapon weaponPrefabComponent;
	private GameObject playerInventory;
	private GameObject playerEquipped;

	private GameObject objToSpawn;
	private Weapon spawnedWeapon;
	private string randomElement;
	private string randomMaterial;
	private string randomType;
	private string randomAttributeType;
	private string generatedWeapon;
	private string generatedDescription;

	public List<string> weaponTypes = new List<string>() {"dagger", "sword", "battleaxe", "staff", "mace", "flail", "spear", "bow", "club", "wand", "book"};
    List<string> weaponElements = new List<string>() {"burning", "frost", "lightning"};
    List<string> weaponAttributeTypes = new List<string>() {"healing", "strength", "intellect", "dexterity", "constitution", "wisdom"};
	// List<string> weaponAttributeTypes = new List<string>() {"strength"};
    List<string> weaponMaterials = new List<string>() {"bone", "paper", "steel", "wood", "copper", "iron", "dragonhide"};

	void Start() {
		weaponPrefab = GameObject.Find("Equipped/Weapon");
		playerInventory = GameObject.Find("Inventory");
		playerEquipped = GameObject.Find("Equipped");
		// GameObject createdWeapon = Instantiate(weaponPrefab, playerInventory.transform);
		// weaponPrefabComponent = createdWeapon.GetComponent<Weapon>();
		// Debug.Log(weaponPrefabComponent);
		// weaponPrefabComponent.weaponName = "Poop";
		// weaponPrefabComponent.name = "Weapon";
		// Debug.Log(weaponPrefabComponent.weaponName);
		// weaponPrefabComponent.weaponStr = 3;
		// Debug.Log(weaponPrefabComponent.weaponStr);
		// weaponPrefabComponent.weaponDamageMin = 3;
		// Debug.Log(weaponPrefabComponent.weaponDamageMin);
		// weaponPrefabComponent.weaponDamageMax = 5;
		// Debug.Log(weaponPrefabComponent.weaponDamageMax);
	}

	public void GenerateWeapon(bool presetWeapon) {
		ResetGenerator();

		if (presetWeapon) {
			Debug.Log("preset weapon is " + presetWeapon + ".");
			Debug.Log("getting preset weapon");
		}
		else {
			Debug.Log("generating random weapon");
			randomType = GenerateType();
			randomElement = GenerateElement();
			randomAttributeType = GenerateAttribute();
			randomMaterial = GenerateMaterial();
			generatedWeapon = randomElement + randomMaterial + " " + randomType + randomAttributeType;
			generatedDescription = randomElement + randomMaterial + " " + randomType + randomAttributeType;
		}

		objToSpawn = new GameObject(generatedWeapon);

		// move to Inventory
		objToSpawn.transform.parent = playerInventory.transform;
		// add Weapon script to newly created game object
		objToSpawn.AddComponent<Weapon>();
		// put the Weapon component (script) in a variable for use
		spawnedWeapon = objToSpawn.GetComponent<Weapon>();
		// set Weapon component variables based on what weapon was just generated
		spawnedWeapon.weaponName = generatedWeapon;
		spawnedWeapon.weaponType = randomType;
		spawnedWeapon.weaponDescription = generatedDescription;
		spawnedWeapon.weaponMaterial = randomMaterial;
		spawnedWeapon.weaponElement = randomElement;
		// GetBaseStats();
		AddAttributeModifiers();
		
		// temp set weapon name to just the type
		// objToSpawn.name = generatedWeapon;
		// find sword weapon text under player inventory
		GameObject findSlot = GameObject.Find("Player/Canvas/Player Inventory/Sword");
		// find player inventory text parent
		GameObject createSlot = GameObject.Find("Player/Canvas/Player Inventory");
		// copy sword weapon and place it in the inventory
		GameObject newSlot = Instantiate(findSlot, createSlot.transform);
		// grab the text component of the sword weapon copied
		Text newSlotText = newSlot.GetComponent<Text>();
		// set the copied sword name of the game object to the generated random weapon type
		newSlot.name = generatedWeapon;
		// scoot the text 30 unit above current position
		newSlot.transform.position += new Vector3(0.0f, 30.0f, 0.0f);
		// find the Player and get the PlayerController component
		PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
		// no idea how but this prepares the PlayerController function ChangeWeapon and
		// will pass in the generated weapon variable
		// temp commenting out
		// UnityEngine.Events.UnityAction action1 = () => { player.ChangeWeapon(generatedWeapon); };
		// add a listener to check for when the copied sword is clicked
		// then run the ChangeWeapon function while passing in randomType
		// newSlot.GetComponent<Button>().onClick.AddListener(action1);
		// set the text to the generated weapon type
		newSlotText.text = generatedWeapon;
	}

	public string GenerateType() {
		string randomType = weaponTypes[Random.Range(0, weaponTypes.Count)];
		
		return randomType;
	}

	string GenerateElement() {
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

	string GenerateAttribute() {
		string randomAttributeType = weaponAttributeTypes[Random.Range(0, weaponAttributeTypes.Count)];
		int hasAttribute = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		string attributeType = "";
		
		if (hasAttribute == 1) {
			attributeType = " of "+ randomAttributeType;
		}
		
		return attributeType;
	}

	string GenerateMaterial() {
		string randomMaterial = weaponMaterials[Random.Range(0, weaponMaterials.Count)];
	
		return randomMaterial;
	}

	void AddAttributeModifiers() {
		Debug.Log("adding attribute modifiers");
		if (randomAttributeType == " of strength") {
			Debug.Log("adding strength modifier");
			Debug.Log("current strength: " + spawnedWeapon.weaponStr);
			spawnedWeapon.weaponStr *= 2;
			Debug.Log("modified strength: " + spawnedWeapon.weaponStr);
		}
		else if (randomAttributeType == " of constitution") {
			Debug.Log("adding constitution modifier");
			spawnedWeapon.weaponCon *= 2;
		}
		else if (randomAttributeType == " of dexterity") {
			Debug.Log("adding dexterity modifier");
			spawnedWeapon.weaponDex *= 2;
		}
		else if (randomAttributeType == " of intellect") {
			Debug.Log("adding intellect modifier");
			spawnedWeapon.weaponInt *= 2;
		}
		else if (randomAttributeType == " of wisdom") {
			Debug.Log("adding wisdom modifier");
			spawnedWeapon.weaponWis *= 2;
		}
		else if (randomAttributeType == " of healing") {
			Debug.Log("adding healing modifier");
			spawnedWeapon.weaponHeal *= 2;
		}
	}

	public void GetBaseStats(Weapon weapon) {
		Debug.Log("getting weapon base stats");
		Debug.Log("random type chosen is " + weapon.weaponType);
		if (weapon.weaponType == "dagger") {
			BaseDagger(weapon);
		}
		else if (weapon.weaponType == "sword") {
			BaseSword(weapon);
		}
		else if (weapon.weaponType == "battleaxe") {
			BaseBattleaxe(weapon);
		}
		else if (weapon.weaponType == "staff") {
			BaseStaff(weapon);
		}
		else if (weapon.weaponType == "mace") {
			BaseMace(weapon);
		}
		else if (weapon.weaponType == "flail") {
			BaseFlail(weapon);
		}
		else if (weapon.weaponType == "bow") {
			BaseBow(weapon);
		}
		else if (weapon.weaponType == "club") {
			BaseClub(weapon);
		}
		else if (weapon.weaponType == "wand") {
			BaseWand(weapon);
		}
		else if (weapon.weaponType == "book") {
			BaseBook(weapon);
		}
	}

	// add weapon stats adjustable by lvl (item lvl??) and rarity
	void BaseDagger(Weapon weapon) {
		Debug.Log("running Base dagger stats");
		weapon.weaponDamageMin = 4;
		weapon.weaponDamageMax = 8;
		weapon.weaponStr = 1;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseSword(Weapon weapon) {
		Debug.Log("running Base sword stats");
		weapon.weaponDamageMin = 8;
		weapon.weaponDamageMax = 12;
		weapon.weaponStr = 2;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseBattleaxe(Weapon weapon) {
		Debug.Log("running Base battleaxe stats");
		weapon.weaponDamageMin = 10;
		weapon.weaponDamageMax = 14;
		weapon.weaponStr = 3;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseStaff(Weapon weapon) {
		Debug.Log("running Base staff stats");
		weapon.weaponDamageMin = 6;
		weapon.weaponDamageMax = 14;
		weapon.weaponStr = 1;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 1;
		weapon.weaponWis = 1;
		weapon.weaponHeal = 0;
	}

	void BaseMace(Weapon weapon) {
		Debug.Log("running Base mace stats");
		weapon.weaponDamageMin = 10;
		weapon.weaponDamageMax = 12;
		weapon.weaponStr = 2;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseFlail(Weapon weapon) {
		Debug.Log("running Base flail stats");
		weapon.weaponDamageMin = 12;
		weapon.weaponDamageMax = 16;
		weapon.weaponStr = 1;
		weapon.weaponCon = 0;
		weapon.weaponDex = 1;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseSpear(Weapon weapon) {
		Debug.Log("running Base spear stats");
		weapon.weaponDamageMin = 5;
		weapon.weaponDamageMax = 10;
		weapon.weaponStr = 1;
		weapon.weaponCon = 0;
		weapon.weaponDex = 1;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseBow(Weapon weapon) {
		Debug.Log("running Base bow stats");
		weapon.weaponDamageMin = 9;
		weapon.weaponDamageMax = 15;
		weapon.weaponStr = 0;
		weapon.weaponCon = 0;
		weapon.weaponDex = 3;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseClub(Weapon weapon) {
		Debug.Log("running Base club stats");
		weapon.weaponDamageMin = 8;
		weapon.weaponDamageMax = 10;
		weapon.weaponStr = 3;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 0;
		weapon.weaponWis = 0;
		weapon.weaponHeal = 0;
	}

	void BaseWand(Weapon weapon) {
		Debug.Log("running Base wand stats");
		weapon.weaponDamageMin = 7;
		weapon.weaponDamageMax = 14;
		weapon.weaponStr = 0;
		weapon.weaponCon = 0;
		weapon.weaponDex = 0;
		weapon.weaponInt = 3;
		weapon.weaponWis = 1;
		weapon.weaponHeal = 0;
	}

	void BaseBook(Weapon weapon) {
		Debug.Log("running Base book stats");
		weapon.weaponDamageMin = 10;
		weapon.weaponDamageMax = 12;
		weapon.weaponStr = 0;
		weapon.weaponCon = 2;
		weapon.weaponDex = 0;
		weapon.weaponInt = 1;
		weapon.weaponWis = 2;
		weapon.weaponHeal = 1;
	}

	private void ResetGenerator() {
		randomElement = "";
		randomMaterial = "";
		randomType = "";
		randomAttributeType = "";
		generatedWeapon = "";
	}
}
