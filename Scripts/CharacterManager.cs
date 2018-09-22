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
	public int characterArmor = 2;
	private int characterBaseHealth = 100;
	public int characterHealthCurrent;
	public int characterHealthMax;

	// character weapon
	private GameObject weapon;
	private Weapon weaponEquipped;
	private int weaponDamage;
	private int damage;

	// character HUD
	private GameObject[] characters;
	private Text characterLevelText;
	private HealthManager characterHealth;
	private bool yourTurn = false;

	// characters in battle
	private GameObject[] playerAllies;
	private GameObject[] enemyAllies;
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

		// armor
		if (this.gameObject.tag == "Enemy Ally") {
			Debug.Log("armor for enemy");
			SetArmorValue();
		}


		// find character level
		// player level is currently setup through
		// player prefs. don't need to keep enemy 
		// levels saved there.
		// characterLevelText = transform.Find("Canvas/Level").GetComponent<Text>();

		// add generic armor
		// for player and enemy

		// add generic weapon
		// for player and enemy

		// possible future addition..
		// add enemy inventory for potions, etc.

		// find players and enemies
		playerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		for (int i = 0; i < playerAllies.Length; i++) {
            Debug.Log("NUMBER " + i + " " + playerAllies[i].name);
        }
		enemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		for (int i = 0; i < enemyAllies.Length; i++) {
            Debug.Log("NUMBER " + i + " " + enemyAllies[i].name);
        }

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
		weaponDamage = Mathf.RoundToInt(Random.Range(1.0f, 15.0f)) + (characterStr / 2);
		
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
		CharacterManager player = playerAllies[Mathf.RoundToInt(Random.Range(0, playerAllies.Length))].GetComponent<CharacterManager>();
		player.TakeDamage(weaponDamage);
	}

	private void AttackEnemy() {
		CharacterManager enemy = enemyAllies[Mathf.RoundToInt(Random.Range(0, enemyAllies.Length))].GetComponent<CharacterManager>();
		enemy.TakeDamage(weaponDamage);
	}

	void SetArmorValue() {
		characterArmor = Mathf.RoundToInt(Random.Range(1.0f, 40.0f));
		Debug.Log(this.name + " armor value is " + characterArmor);
	}

	public void TakeDamage(int damage) {
		Debug.Log("unmitigated damage is " + damage);
		int armorDamageReduction = Mathf.RoundToInt(characterArmor * .1f);
		damage = damage - armorDamageReduction;
		Debug.Log("damage with armor on is " + damage);
		characterHealth.Health(this.name, damage);
	}

	public void TakeTurn() {
		Debug.Log(this.name + " is taking their turn");
		yourTurn = true;
	}

	public void CharacterDied() {
		Debug.Log(this + " character has died");
		turnOrderManager.RemoveCharacterTurn(this.name);
	}
}
