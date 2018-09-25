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
	// private GameObject[] findPlayers;
	// private List<CharacterManager> playerAllies = new List<CharacterManager>();
	// private GameObject[] findEnemies;
	// private List<CharacterManager> enemyAllies = new List<CharacterManager>();
	// private List<CharacterManager> charactersInBattle = new List<CharacterManager>();
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
		SetArmorValue();


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
		CharacterManager character = turnOrderManager.ChoosePlayerHit();
		if (character != null) {
			character.TakeDamage(weaponDamage);
		}
		// int playersAlive = playerAllies.Count;
		// Debug.Log("player count is " + playersAlive);
		// if (playersAlive > 0) {
		// 	Debug.Log("players are alive");
		// 	CharacterManager player = playerAllies[Mathf.RoundToInt(Random.Range(0, playerAllies.Count))];

		// 	player.TakeDamage(weaponDamage);
		// }
		// else {
		// 	AllPlayersDead();
		// }
	}

	private void AttackEnemy() {
		CharacterManager character = turnOrderManager.ChooseEnemyHit();
		if (character != null) {
			character.TakeDamage(weaponDamage);
		}
		// int enemiesAlive = enemyAllies.Count;
		// Debug.Log("enemy count is " + enemiesAlive);
		// if (enemiesAlive > 0) {
		// 	Debug.Log("enemies are alive");
		// 	CharacterManager enemy = enemyAllies[Mathf.RoundToInt(Random.Range(0, enemyAllies.Count))];
			
		// 	enemy.TakeDamage(weaponDamage);
		// }
		// else {
		// 	AllEnemiesDead();
		// }
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
		// // remove from list of characters in battle
		// if (this.gameObject.tag == "Player Ally") {
		// 	Debug.Log("removing " + this + " from player list");
		// 	playerAllies.Remove(this);
		// 	for (int i = 0; i < playerAllies.Count; i++) {
		// 		Debug.Log("players left " + playerAllies[i]);
		// 	}
		// }
		// else if (this.gameObject.tag == "Enemy Ally") {
		// 	Debug.Log("removing " + this + " from enemy list");
		// 	enemyAllies.Remove(this);
		// 	for (int i = 0; i < enemyAllies.Count; i++) {
		// 		Debug.Log("enemies left " + enemyAllies[i]);
		// 	}
		// }

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
