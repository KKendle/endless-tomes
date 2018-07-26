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

	List<string> weaponTypes = new List<string>() {"dagger", "sword", "battleaxe", "staff", "mace", "flail", "spear", "bow", "club", "wand", "book"};
	// List<string> weaponTypes = new List<string>() {"dagger"};
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

	public void generateWeapon() {
		resetGenerator();

		randomType = generateType();
		randomElement = generateElement();
		randomAttributeType = generateAttribute();
		randomMaterial = generateMaterial();
		generatedWeapon = randomElement + randomMaterial + " " + randomType + randomAttributeType;

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
		getBaseStats();
		addAttributeModifiers();
		
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
		UnityEngine.Events.UnityAction action1 = () => { player.ChangeWeapon(generatedWeapon); };
		// add a listener to check for when the copied sword is clicked
		// then run the ChangeWeapon function while passing in randomType
		newSlot.GetComponent<Button>().onClick.AddListener(action1);
		// set the text to the generated weapon type
		newSlotText.text = generatedWeapon;
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

	void addAttributeModifiers() {
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

	public void getBaseStats() {
		Debug.Log("getting weapon base stats");
		Debug.Log("random type chosen is " + randomType);
		if (randomType == "dagger") {
			baseDagger();
		}
		else if (randomType == "sword") {
			baseSword();
		}
		else if (randomType == "battleaxe") {
			baseBattleaxe();
		}
		else if (randomType == "staff") {
			baseStaff();
		}
		else if (randomType == "mace") {
			baseMace();
		}
		else if (randomType == "flail") {
			baseFlail();
		}
		else if (randomType == "bow") {
			baseBow();
		}
		else if (randomType == "club") {
			baseClub();
		}
		else if (randomType == "wand") {
			baseWand();
		}
		else if (randomType == "book") {
			baseBook();
		}
	}

	void baseDagger() {
		Debug.Log("running base dagger stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 2;
		spawnedWeapon.weaponStr = 3;
		spawnedWeapon.weaponCon = 4;
		spawnedWeapon.weaponDex = 5;
		spawnedWeapon.weaponInt = 6;
		spawnedWeapon.weaponWis = 7;
		spawnedWeapon.weaponHeal = 8;
	}

	void baseSword() {
		Debug.Log("running base sword stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseBattleaxe() {
		Debug.Log("running base battleaxe stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseStaff() {
		Debug.Log("running base staff stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseMace() {
		Debug.Log("running base mace stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseFlail() {
		Debug.Log("running base flail stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseSpear() {
		Debug.Log("running base spear stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseBow() {
		Debug.Log("running base bow stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseClub() {
		Debug.Log("running base club stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseWand() {
		Debug.Log("running base wand stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	void baseBook() {
		Debug.Log("running base book stats");
		spawnedWeapon.weaponDamageMin = 1;
		spawnedWeapon.weaponDamageMax = 1;
		spawnedWeapon.weaponStr = 1;
		spawnedWeapon.weaponCon = 1;
		spawnedWeapon.weaponDex = 1;
		spawnedWeapon.weaponInt = 1;
		spawnedWeapon.weaponWis = 1;
		spawnedWeapon.weaponHeal = 1;
	}

	private void resetGenerator() {
		randomElement = "";
		randomMaterial = "";
		randomType = "";
		randomAttributeType = "";
		generatedWeapon = "";
	}
}
