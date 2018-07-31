using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int playerLevel = 1;
    public static int playerXP = 0;
    public static int playerStr = 10;
    public static int playerCon = 10;
    public static int playerBaseHealth = 100;
    public static int playerArmor = 2;
    public static int playerHealthCurrent;
    public static int playerHealthMax;

    private int weaponDamage;
    private int damage;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private GameObject weapon;
    private Weapon weaponEquipped;
    // private static Text playerHealthText;
    private static Text playerLevelText;
    private static Text playerXPText;
    private static Text currentWeaponText;
    private static string currentWeapon;

	private Weapon weaponPrefabComponent;
	private GameObject playerInventory;
	private GameObject playerEquipped;

    // static otherwise I lose the reference somehow
    public static GameObject equippedItemsContainer;
    public static GameObject inventoryItemsContainer;

	void Start() {
        playerHealth = transform.Find("Canvas/Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            Debug.Log(this + "should have found Player Health");
        }
        // playerHealthText = transform.Find("Canvas/Health").GetComponent<Text>();
        // playerHealthText.text = "HP " + playerHealthCurrent + "/" + playerHealthMax;

        enemyHealth = GameObject.Find("Enemy Health").GetComponent<EnemyHealth>();
        if (enemyHealth != null) {
            // Debug.Log(this + "should have found Enemy Health");
        }

        // looks for Equipped and then for Weapon underneath that
        // only search one level deep, not recursive
        weapon = GameObject.Find("Equipped/Weapon");
        weaponEquipped = weapon.GetComponent<Weapon>();
        if (weapon != null) {
            Debug.Log(this + "should have found weapon");
            Debug.Log("weapon equipped is " + weapon);
            Debug.Log("name of weapon equipped is " + weaponEquipped.weaponName);
        }
        playerInventory = GameObject.Find("Inventory");
		playerEquipped = GameObject.Find("Equipped");
        if (playerInventory != null) {
            Debug.Log(this + "should have found player inventory");
        }
        if (playerEquipped != null) {
            Debug.Log(this + "should have found player equipped");
        }

        // show level of player
        playerLevelText = transform.Find("Canvas/Level").GetComponent<Text>();
        playerLevelText.text = "Lvl " + playerLevel.ToString();

        // show experience points of player
        playerXPText = transform.Find("Canvas/Experience").GetComponent<Text>();
        playerXPText.text = "XP " + playerXP.ToString() + "/" + "0";

        // currentWeaponText = GameObject.Find("Player Weapon Equipped").GetComponent<Text>();
        // currentWeapon = currentWeaponText.text.ToString();
        // Debug.Log("current weapon found is " + currentWeaponText);
        // Debug.Log("current weapon variable " + currentWeapon);

        // get total armor value
        Debug.Log("player armor is " + playerArmor);
        // grab all the equipped armors defense value
        Armor equippedHelm = GameObject.Find("Equipped/Helm").GetComponent<Armor>();
        Debug.Log("player helm is " + equippedHelm.armorDefense);
        Armor equippedChestplate = GameObject.Find("Equipped/Chestplate").GetComponent<Armor>();
        Debug.Log("player chestplate is " + equippedChestplate.armorDefense);
        Armor equippedBracers = GameObject.Find("Equipped/Bracers").GetComponent<Armor>();
        Debug.Log("player bracers is " + equippedBracers.armorDefense);
        Armor equippedLegs = GameObject.Find("Equipped/Legs").GetComponent<Armor>();
        Debug.Log("player legs is " + equippedLegs.armorDefense);
        Armor equippedBoots = GameObject.Find("Equipped/Boots").GetComponent<Armor>();
        Debug.Log("player boots is " + equippedBoots.armorDefense);

        // add it all together
        playerArmor += equippedHelm.armorDefense + equippedChestplate.armorDefense + equippedBracers.armorDefense + equippedLegs.armorDefense + equippedBoots.armorDefense;
        Debug.Log("player armor is " + playerArmor);

        // find player equipped items screen
        equippedItemsContainer = GameObject.Find("Equipped Items Container");
        equippedItemsContainer.SetActive(false);

        // find player inventory items screen
        inventoryItemsContainer = GameObject.Find("Inventory Items Container");
        inventoryItemsContainer.SetActive(false);

        playerHealth.Reset();
	}

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Attack();
		}

        if(playerHealthCurrent <= 0) {
            Debug.Log("Player health is zero or below. dying. " + playerHealthCurrent);
            Die();
        }
    }

    void Attack() {
        Debug.Log("Player attacking");
        // weaponDamage = weaponEquipped.WeaponDamage(currentWeapon);
        weaponDamage = weaponEquipped.WeaponDamage();
        // weaponDamage = 100;
        // Debug.Log("weapon damage from " + currentWeapon + " is " + weaponDamage);
        damage = Mathf.RoundToInt(weaponDamage + (playerStr / 2));
        // Debug.Log("player str " + playerStr);
        Debug.Log("total player damage " + damage);
        enemyHealth.Health(damage);
        // Debug.Log("Enemy health is now at " + EnemyHealth.enemyHealth);
    }

    public void ChangeWeapon(string newWeapon) {
        Debug.Log("changing weapons");
        Debug.Log("current weapon is " + currentWeaponText);
        newWeapon = newWeapon.ToLower();
        Debug.Log("weapon changing to " + newWeapon);
        currentWeaponText.text = newWeapon;
        Debug.Log("current weapon is now " + currentWeaponText);
        currentWeapon = currentWeaponText.text.ToString();
        Debug.Log("current weapon variable " + currentWeapon);

        // move currently equipped weapon to inventory
        // change currently equipped weapon to name of weapon
        weaponEquipped.name = weaponEquipped.weaponName.ToLower();
        // move currently equipped weapon from Equipped to Inventory
        weaponEquipped.transform.parent = playerInventory.transform;

        // move selected weapon to equipped
        // find selected weapon
        GameObject weaponToEquip = GameObject.Find(newWeapon);
        Weapon newEquippedWeapon = weaponToEquip.GetComponent<Weapon>();
        // change name to Weapon for usage by Player
        newEquippedWeapon.name = "Weapon";
        // move to equipped
        newEquippedWeapon.transform.parent = playerEquipped.transform;

        // get the new reference to the equipped weapon
        weapon = GameObject.Find("Equipped/Weapon");
        weaponEquipped = weapon.GetComponent<Weapon>();
    }

    public void closeWindow() {
        Debug.Log("closing window " + EventSystem.current.currentSelectedGameObject.name);
        // gets the current selected (clicked, in this case) game object
        // grab transform, get it's parent, grab just the parent gameobject
        // set it to inactive
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    public void openChildWindow() {
        Debug.Log("opening child window of " + EventSystem.current.currentSelectedGameObject.name);
        // gets the current selected (clicked, in this case) game object
        GameObject objToOpen = EventSystem.current.currentSelectedGameObject;
        // grab transform, get the first child, grab just the gameobject
        // set it to active
        objToOpen.transform.GetChild(0).gameObject.SetActive(true);

        if (objToOpen.tag == "Slot") {
            Debug.Log("opening a slot");
            displayWeaponDetails(objToOpen);
        }
    }

    public void displayWeaponDetails(GameObject itemObj) {
        Debug.Log("displaying item details for " + itemObj.name);
        string itemName = itemObj.name.Substring(0, itemObj.name.Length - 5);
        Debug.Log("item name is shortened to " + itemName + ".");
        GameObject item = GameObject.Find(itemName);
        Weapon itemDetails = item.GetComponent<Weapon>();
        Debug.Log("item details type is " + itemDetails.weaponType + ".");
        // weapon name
        itemObj.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = itemDetails.weaponName;
        // weapon type
        itemObj.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Text>().text = itemDetails.weaponType;
        // weapon damage
        itemObj.transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Text>().text = itemDetails.weaponDamageMin + " - " + itemDetails.weaponDamageMax;
    }

    public void CalculateXP(int xp) {
        Debug.Log("Current XP " + playerXP);
        Debug.Log("XP gained " + xp);
        Debug.Log("Calculating XP");
        playerXP += xp;
        Debug.Log("Current XP " + playerXP);
        playerXPText.text = "XP " + playerXP.ToString() + "/" + "0";
    }

	void Die() {
		Debug.Log("Player Died");
		// Destroy(gameObject);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}
