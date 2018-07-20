using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int playerLevel = 1;
    public static int playerXP = 0;
    public static int playerStr = 10;
    public static int playerCon = 10;
    public static int playerBaseHealth = 100;
    public static int playerHealthMax;

    private int weaponDamage;
    private int damage;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private GameObject weapon;
    private Weapon weaponEquipped;
    private static Text playerLevelText;
    private static Text playerXPText;
    private static Text currentWeaponText;
    private static string currentWeapon;

	private Weapon weaponPrefabComponent;
	private GameObject playerInventory;
	private GameObject playerEquipped;

	void Start() {
        playerHealth = GameObject.Find("Player Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            // Debug.Log(this + "should have found Player Health");
        }

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

        // gets max health of player
        playerHealthMax = Mathf.RoundToInt(playerBaseHealth + (playerCon * 2));

        // show level of player
        playerLevelText = GameObject.Find("Player Level").GetComponent<Text>();
        playerLevelText.text = playerLevel.ToString();

        // show experience points of player
        playerXPText = GameObject.Find("Player XP").GetComponent<Text>();
        playerXPText.text = playerXP.ToString();

        currentWeaponText = GameObject.Find("Player Weapon Equipped").GetComponent<Text>();
        currentWeapon = currentWeaponText.text.ToString();
        Debug.Log("current weapon found is " + currentWeaponText);
        Debug.Log("current weapon variable " + currentWeapon);

        PlayerHealth.Reset();
	}

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Attack();
		}

        if(PlayerHealth.playerHealth <= 0) {
            Debug.Log("Player health is zero or below. dying. " + PlayerHealth.playerHealth);
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
        Debug.Log("weapon changing to " + newWeapon);
        currentWeaponText.text = newWeapon;
        Debug.Log("current weapon is now " + currentWeaponText);
        currentWeapon = currentWeaponText.text.ToString();
        Debug.Log("current weapon variable " + currentWeapon);

        // move currently equipped weapon to inventory
        // change currently equipped weapon to name of weapon
        weaponEquipped.name = weaponEquipped.weaponName;
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

    public void CalculateXP(int xp) {
        Debug.Log("Current XP " + playerXP);
        Debug.Log("XP gained " + xp);
        Debug.Log("Calculating XP");
        playerXP += xp;
        Debug.Log("Current XP " + playerXP);
    }

	void Die() {
		Debug.Log("Player Died");
		// Destroy(gameObject);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}
