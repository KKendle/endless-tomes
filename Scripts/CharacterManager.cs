using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour {

	// character stats
	public int characterLevel = 1;
	public int characterStr = 10;
	public int characterCon = 10;
	public int characterDex = 0;
	public int characterInt = 0;
	public int characterWis = 0;
	public int characterHeal = 0;
	public int characterArmor = 2;
	private int characterBaseHealth = 100;
	public int characterHealthCurrent;
	public int characterHealthMax;

	// character weapon
	private GameObject weapon;
	private WeaponGenerator weaponGenerator;
	private Weapon weaponEquipped;
	private int weaponDamage;
	private int damage;

	// character HUD
	private GameObject[] characters;
	private Text characterLevelText;
	private HealthManager characterHealth;
	private bool yourTurn = false;
	private bool attackAnyCharacter = false;
	private bool attackAllCharacters = false;

	// managers
	private LevelUpManager levelUpManager;
	private TurnOrderManager turnOrderManager;

	void Start() {
		Debug.Log("running start of CharacterManager for " + this.name);

		//
		// FINDING COMPONENTS
		//

		// find character health
		characterHealth = transform.Find("Canvas/Health").GetComponent<HealthManager>();
		if (characterHealth != null) {
			Debug.Log("should have found health text for " + this.name);
		}

		// find turn order manager
		turnOrderManager = GameObject.Find("TurnOrderManager").GetComponent<TurnOrderManager>();

		//
		// SET STATS
		//
		
		// health
		characterHealthMax = Mathf.RoundToInt(characterBaseHealth + (characterCon * 2));

		// find character level
		// player level is currently setup through
		// player prefs. don't need to keep enemy 
		// levels saved there.
		// characterLevelText = transform.Find("Canvas/Level").GetComponent<Text>();

		// add generic armor
		// for player and enemy
		Armor equippedHelm = transform.Find("Equipped/Helm").GetComponent<Armor>();
		Armor equippedShoulders = transform.Find("Equipped/Shoulders").GetComponent<Armor>();
        Armor equippedChestplate = transform.Find("Equipped/Chestplate").GetComponent<Armor>();
        Armor equippedBracers = transform.Find("Equipped/Bracers").GetComponent<Armor>();
		Armor equippedGloves = transform.Find("Equipped/Gloves").GetComponent<Armor>();
        Armor equippedLegs = transform.Find("Equipped/Legs").GetComponent<Armor>();
        Armor equippedBoots = transform.Find("Equipped/Boots").GetComponent<Armor>();

		// add generic weapon
		// for player and enemy
		if (this.tag == "Enemy Ally") {
			EnemyController enemyController = GetComponent<EnemyController>();
			weaponEquipped = enemyController.SetStartingWeapon();
			equippedHelm = enemyController.SetHelm();
			equippedShoulders = enemyController.SetShoulders();
			equippedChestplate = enemyController.SetChestplate();
			equippedBracers = enemyController.SetBracers();
			equippedGloves = enemyController.SetGloves();
			equippedLegs = enemyController.SetLegs();
			equippedBoots = enemyController.SetBoots();
		}
		else {
			weaponEquipped = transform.Find("Equipped/Weapon").GetComponent<Weapon>();
		}
		// add equipped item stats to character stats
		AddWeaponStats(weaponEquipped);
		AddArmorStats(equippedHelm);
		AddArmorStats(equippedShoulders);
		AddArmorStats(equippedChestplate);
		AddArmorStats(equippedBracers);
		AddArmorStats(equippedGloves);
		AddArmorStats(equippedLegs);
		AddArmorStats(equippedBoots);

		// possible future addition..
		// add enemy inventory for potions, etc.

		// reset character health(s)
		characterHealth.Reset(this.name);
	}

	void Update() {
		if (yourTurn) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log(this.name + " is attacking");
				yourTurn = false;
				Attack();
			}
		}
	}

	void Attack() {
		weaponDamage = weaponEquipped.WeaponDamage(this);
		
		// attack player or enemy
		Debug.Log("character has tag of " + this.gameObject.tag);
		if (attackAnyCharacter) {
			Debug.Log("attacking any Character");
			int attackPlayerOrEnemy = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));

			if (this.gameObject.tag == "Player Ally") {
				Debug.Log("is Player ally. less chance to hit teammates");
				Debug.Log("roll result is " + attackPlayerOrEnemy);
				if (attackPlayerOrEnemy <= 1) {
					Debug.Log("attacking Player");
					AttackPlayer();
				}
				else {
					Debug.Log("attacking Enemy");
					AttackEnemy();
				}
			}
			else if (this.gameObject.tag == "Enemy Ally") {
				Debug.Log("is Enemy ally. less chance to hit teammates");
				Debug.Log("roll result is " + attackPlayerOrEnemy);
				if (attackPlayerOrEnemy <= 1) {
					Debug.Log("attacking Enemy");
					AttackEnemy();
				}
				else {
					Debug.Log("attacking Player");
					AttackPlayer();
				}
			}
		}
		else {
			if (this.gameObject.tag == "Player Ally") {
				Debug.Log("this is a Player ally - attacking enemy");
				AttackEnemy();
			}
			else if (this.gameObject.tag == "Enemy Ally") {
				Debug.Log("this is an Enemy ally - attacking player");
				AttackPlayer();
			}
		}

		turnOrderManager.EndTurn();
	}

	private void AttackPlayer() {
		CharacterManager character = turnOrderManager.ChoosePlayerHit();
		if (character != null) {
			character.TakeDamage(weaponDamage);
		}
	}

	private void AttackEnemy() {
		CharacterManager character = turnOrderManager.ChooseEnemyHit();
		if (character != null) {
			character.TakeDamage(weaponDamage);
		}
	}

	private void AddWeaponStats(Weapon weaponEquipped) {
		Debug.Log("adding stats from " + weaponEquipped.weaponName);
		characterStr += weaponEquipped.weaponStr;
		characterCon += weaponEquipped.weaponCon;
		characterDex += weaponEquipped.weaponDex;
		characterInt += weaponEquipped.weaponInt;
		characterWis += weaponEquipped.weaponWis;
		characterHeal += weaponEquipped.weaponHeal;
	}

	private void AddArmorStats(Armor armorEquipped) {
		Debug.Log("adding stats from " + armorEquipped.armorName);
		characterArmor += armorEquipped.armorDefense;
		characterStr += armorEquipped.armorStr;
		characterCon += armorEquipped.armorCon;
		characterDex += armorEquipped.armorDex;
		characterInt += armorEquipped.armorInt;
		characterWis += armorEquipped.armorWis;
		characterHeal += armorEquipped.armorHeal;
	}

	public void TakeDamage(int damage) {
		Debug.Log("unmitigated damage is " + damage);
		int armorDamageReduction = Mathf.RoundToInt(characterArmor * .1f);
		damage = damage - armorDamageReduction;
		if (damage < 0 ) {
			damage = 0;
		}
		Debug.Log("damage with armor on is " + damage);
		characterHealth.Health(this.name, damage);
	}

	public void TakeTurn() {
		Debug.Log(this.name + " is taking their turn");
		yourTurn = true;
	}

	public void CharacterDied() {
		Debug.Log(this + " character has died");
		// remove from turn order
		turnOrderManager.RemoveCharacterTurn(this);
	}

	public void AllPlayersDead() {
		Debug.Log("All players are dead. you lose");
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
	}

	public void AllEnemiesDead() {
		Debug.Log("All enemies are dead. you lose");
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win");
	}
}
