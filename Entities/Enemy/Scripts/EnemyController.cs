using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Weapon SetStartingWeapon() {
        WeaponGenerator weaponGenerator = GameObject.Find("LootManager").GetComponent<WeaponGenerator>();
		string randomWeaponType = weaponGenerator.GenerateType();

		Weapon weaponEquipped = transform.Find("Equipped/Weapon").GetComponent<Weapon>();
		weaponEquipped.SetWeaponType(randomWeaponType);
        weaponGenerator.GetBaseStats(weaponEquipped);

        return weaponEquipped;
    }

    // public int enemyLevel = 1;
    // public int enemyStr = 5;
    // public int enemyCon = 10;
    // public int enemyArmor = 2;
    // public int enemyXPValue = 35;
    // private int enemyBaseHealth = 100;
    // public int enemyHealthCurrent;
    // public int enemyHealthMax;
    // // public Sword weapon;

    // private GameObject[] playerAllies;

    // private int weaponDamage;
    // private int damage;
    // // turn related
    // private bool yourTurn = false;
	// private EnemyHealth enemyHealth;
    // // private PlayerController player;
    // private PlayerController[] player = new PlayerController[2];
    // private PlayerHealth playerHealth;
    // // ally
    // // private PlayerController ally;
    // private PlayerHealth allyHealth;

    // private TurnOrderManager turnOrderManager;

	// void Start() {
    //     Debug.Log("running Enemy Controller");
    //     playerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
    //     Debug.Log("number of player allies is " + playerAllies.Length);
    //     for (int i = 0; i < playerAllies.Length; i++) {
    //         Debug.Log(i + " " + playerAllies[i].name);
    //         Debug.Log(playerAllies[i].GetComponent<PlayerController>());
    //         player[i] = playerAllies[i].GetComponent<PlayerController>();
    //     }

    //     enemyHealth = transform.Find("Canvas/Health").GetComponent<EnemyHealth>();
    //     if (enemyHealth != null) {
    //         Debug.Log(this + "should have found Enemy Health");
    //     }

    //     // playerHealth = GameObject.Find(allies[0].name + "/Canvas/Health").GetComponent<PlayerHealth>();
    //     // if (playerHealth != null) {
    //     //     Debug.Log(playerHealth);
    //     //     Debug.Log(this + "should have found Player Health");
    //     // }

    //     // player = GameObject.Find(playerAllies[0].name).GetComponent<PlayerController>();
    //     // if (player != null) {
    //     //     Debug.Log(player);
    //     //     Debug.Log(this + "should have found Player");
    //     // }

    //     // allyHealth = GameObject.Find(allies[1].name + "/Canvas/Health").GetComponent<PlayerHealth>();
    //     // if (allyHealth != null) {
    //     //     Debug.Log(allyHealth);
    //     //     Debug.Log(this + "should have found Ally Health");
    //     // }

    //     // ally = GameObject.Find(playerAllies[1].name).GetComponent<PlayerController>();
    //     // if (ally != null) {
    //     //     Debug.Log(ally);
    //     //     Debug.Log(this + "should have found Ally");
    //     // }

    //     enemyHealthMax = Mathf.RoundToInt(enemyBaseHealth + (enemyCon * 2));

    //     // find turn order manager
    //     turnOrderManager = GameObject.Find("TurnOrderManager").GetComponent<TurnOrderManager>();

    //     setArmorValue();

    //     enemyHealth.Reset(this.name);
	// }

    // void Update() {
    //     if (yourTurn) {
    //         if(Input.GetKeyDown(KeyCode.Space)) {
    //             Debug.Log(this.name + " is attacking");
    //             yourTurn = false;
    //             Attack();
    //         }
    //     }

    //     if(enemyHealthCurrent <= 0) {
    //         // Debug.Log("Enemy health is zero or below. dying. " + enemyHealthCurrent);
    //         Die();
    //     }
    // }

    // void setArmorValue() {
    //     enemyArmor = Mathf.RoundToInt(Random.Range(1.0f, 40.0f));
    //     Debug.Log(this.name + " armor value is " + enemyArmor);
    // }

    // void Attack() {
    //     // Debug.Log("Enemy Attacking");
    //     // weaponDamage = weapon.WeaponDamage();
    //     weaponDamage  = Mathf.RoundToInt(Random.Range(5, 15)) + (enemyStr / 2);
    //     // Debug.Log("enemy str " + enemyStr);
    //     // Debug.Log("enemy rounded " + Mathf.RoundToInt(enemyStr / 2));
    //     damage = Mathf.RoundToInt(weaponDamage + (enemyStr / 2));
    //     // Debug.Log("Total enemy damage - rounded " + damage);
    //     player[Mathf.RoundToInt(Random.Range(0, playerAllies.Length))].TakeDamage(damage);
    //     // playerHealth.Health(enemyWeapon.GetDamage());
    //     // Debug.Log("Player health is now at " + PlayerHealth.playerHealth);

    //     turnOrderManager.EndTurn();
    // }

    // public void TakeDamage(int damage) {
    //     Debug.Log("taking " + damage + " amount");
    //     int armorDamageReduction = Mathf.RoundToInt(enemyArmor * .1f);
    //     Debug.Log(this.name + " armor is negating " + armorDamageReduction + " damage");
    //     damage = damage - armorDamageReduction;
    //     Debug.Log(this.name + " is taking " + damage + " damage");
    //     enemyHealth.Health(this.name, damage);
    // }

    // public void TakeTurn() {
    //     Debug.Log(this.name + " is taking their turn");
    //     yourTurn = true;
    // }

	// void Die() {
	// 	// Debug.Log("Enemy Died");
	// 	// Destroy(gameObject);
    //     for (int i = 0; i < playerAllies.Length; i++) {
    //         Debug.Log(player[i]);
    //         player[i].CalculateXP(enemyXPValue);
    //     }

    //     // check loot
    //     LootManager lootManager = GameObject.Find("LootManager").GetComponent<LootManager>();
    //     lootManager.enemyDrops();

    //     // next level
	// 	LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	// 	levelManager.LoadLevel("Win");
	// }
}
