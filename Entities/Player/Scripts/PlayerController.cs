using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int playerLevel = 1;
    public int playerXP;
    public int playerXPNextLevel = 83;
    public int playerStr = 10;
    public int playerCon = 10;
    public int playerArmor = 2;
    public int playerBaseHealth = 100;
    public int playerHealthCurrent;
    public int playerHealthMax;

    private int weaponDamage;
    private int damage;
    private GameObject[] playerAllies;
    private PlayerController[] player = new PlayerController[2];
    private PlayerHealth playerHealth;
    private GameObject[] enemyAllies;
    private EnemyController[] enemy = new EnemyController[2];
    private GameObject weapon;
    private Weapon weaponEquipped;
    // private static Text playerHealthText;
    private Text playerLevelText;
    private Text playerXPText;
    private static Text currentWeaponText;
    private static string currentWeapon;

	private Weapon weaponPrefabComponent;
	private GameObject playerInventory;
	private GameObject playerEquipped;

    // turn related
    private bool yourTurn = false;

    private LevelUpManager levelUpManager;
    private TurnOrderManager turnOrderManager;

    // static otherwise I lose the reference somehow
    public static GameObject equippedItemsContainer;
    public static GameObject inventoryItemsContainer;

	void Start() {
        Debug.Log("running start of PlayerController");
        Debug.Log(this.name);

        // find allies
        playerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
        Debug.Log("number of player allies is " + playerAllies.Length);
        for (int i = 0; i < playerAllies.Length; i++) {
            Debug.Log(i + " " + playerAllies[i].name);
            Debug.Log(playerAllies[i].GetComponent<PlayerController>());
            player[i] = playerAllies[i].GetComponent<PlayerController>();
        }

        // find enemies
        enemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
        Debug.Log("number of enemy allies is " + enemyAllies.Length);
        for (int i = 0; i < enemyAllies.Length; i++) {
            Debug.Log(i + " " + enemyAllies[i].name);
            Debug.Log(enemyAllies[i].GetComponent<EnemyController>());
            enemy[i] = enemyAllies[i].GetComponent<EnemyController>();
        }

        playerHealth = transform.Find("Canvas/Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            Debug.Log(this + "should have found Player Health");
        }
        // playerHealthText = transform.Find("Canvas/Health").GetComponent<Text>();
        // playerHealthText.text = "HP " + playerHealthCurrent + "/" + playerHealthMax;

        // enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
        // if (enemy != null) {
        //     Debug.Log(this + "should have found Enemy ");
        // }

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
        // PlayerPrefs.GetInt(this.name + " level", 1);
        PlayerPrefs.SetInt(this.name + " level", PlayerPrefs.GetInt(this.name + " level", 1));
        playerLevelText.text = "Lvl " + PlayerPrefs.GetInt(this.name + " level");

        // show experience points of player
        playerXPText = transform.Find("Canvas/Experience").GetComponent<Text>();
        // PlayerPrefs.GetInt(this.name + " experience", 0);
        PlayerPrefs.SetInt(this.name + " experience", PlayerPrefs.GetInt(this.name + " experience", 0));
        playerXPText.text = "XP " + PlayerPrefs.GetInt(this.name + " experience") + "/" + playerXPNextLevel;

        levelUpManager = GameObject.Find("LevelUpManager").GetComponent<LevelUpManager>();

        // currentWeaponText = GameObject.Find("Player Weapon Equipped").GetComponent<Text>();
        // currentWeapon = currentWeaponText.text.ToString();
        // Debug.Log("current weapon found is " + currentWeaponText);
        // Debug.Log("current weapon variable " + currentWeapon);

        // get total armor value
        Debug.Log(this.name + " armor is " + playerArmor);
        // grab all the equipped armors defense value
        Armor equippedHelm = GameObject.Find("Equipped/Helm").GetComponent<Armor>();
        // Debug.Log(this.name + " helm is " + equippedHelm.armorDefense);
        Armor equippedChestplate = GameObject.Find("Equipped/Chestplate").GetComponent<Armor>();
        // Debug.Log(this.name + " chestplate is " + equippedChestplate.armorDefense);
        Armor equippedBracers = GameObject.Find("Equipped/Bracers").GetComponent<Armor>();
        // Debug.Log(this.name + " bracers is " + equippedBracers.armorDefense);
        Armor equippedLegs = GameObject.Find("Equipped/Legs").GetComponent<Armor>();
        // Debug.Log(this.name + " legs is " + equippedLegs.armorDefense);
        Armor equippedBoots = GameObject.Find("Equipped/Boots").GetComponent<Armor>();
        // Debug.Log(this.name + " boots is " + equippedBoots.armorDefense);

        // add it all together
        playerArmor += equippedHelm.armorDefense + equippedChestplate.armorDefense + equippedBracers.armorDefense + equippedLegs.armorDefense + equippedBoots.armorDefense;
        Debug.Log(this.name + " armor is " + playerArmor);

        // find player equipped items screen
        equippedItemsContainer = GameObject.Find("Equipped");
        equippedItemsContainer.SetActive(false);

        // find player inventory items screen
        inventoryItemsContainer = GameObject.Find("Inventory");
        inventoryItemsContainer.SetActive(false);

        // find turn order manager
        turnOrderManager = GameObject.Find("TurnOrderManager").GetComponent<TurnOrderManager>();

        playerHealth.Reset(this.name);
	}

    void Update() {
        if (yourTurn) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(this.name + " is attacking");
                yourTurn = false;
                Attack();
            }
        }

        if(playerHealthCurrent <= 0) {
            Debug.Log(this.name + " health is zero or below. dying. " + playerHealthCurrent);
            Die();
        }
    }

    void Attack() {
        Debug.Log(this.name + " attacking");
        // weaponDamage = weaponEquipped.WeaponDamage(currentWeapon);
        weaponDamage = weaponEquipped.WeaponDamage();
        // weaponDamage = 100;
        // Debug.Log("weapon damage from " + currentWeapon + " is " + weaponDamage);
        damage = Mathf.RoundToInt(weaponDamage + (playerStr / 2));
        // Debug.Log("player str " + playerStr);
        Debug.Log("total player damage " + damage);
        enemy[Mathf.RoundToInt(Random.Range(0, enemyAllies.Length))].TakeDamage(damage);
        // enemy.TakeDamage(damage);
        // Debug.Log("Enemy health is now at " + EnemyHealth.enemyHealth);

        turnOrderManager.EndTurn();
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
        Debug.Log("xp gained is " + xp);
        PlayerPrefs.SetInt(this.name + " experience", PlayerPrefs.GetInt(this.name + " experience") + xp);

        playerXPText.text = "XP " + PlayerPrefs.GetInt(this.name + " experience") + "/" + playerXPNextLevel;
        levelUpManager.CheckLvlUp(this.name);
    }

    public void TakeDamage(int damage) {
        Debug.Log("taking " + damage + " amount");
        int armorDamageReduction = Mathf.RoundToInt(playerArmor * .1f);
        Debug.Log(this.name + " armor is negating " + armorDamageReduction + " damage");
        damage = damage - armorDamageReduction;
        Debug.Log(this.name + " is taking " + damage + " damage");
        playerHealth.Health(this.name, damage);
    }

    public void TakeTurn() {
        Debug.Log(this.name + " is taking their turn");
        yourTurn = true;
    }

	void Die() {
		Debug.Log("Player Died");
		// Destroy(gameObject);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}
