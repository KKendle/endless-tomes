using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderManager : MonoBehaviour {

	private CharacterManager currentTurn;
	private int currentTurnPosition = 0;
	private bool alliesTurn = false;
	private bool enemiesTurn = false;
	private int allyTurnCount = 0;
	private int enemyTurnCount = 0;
	private CharacterManager[] findCharacters;
	private List<CharacterManager> charactersInBattle = new List<CharacterManager>();
	private GameObject[] findPlayerAllies;
	private List<CharacterManager> playerAllies = new List<CharacterManager>();
	private GameObject[] findEnemyAllies;
	private List<CharacterManager> enemyAllies = new List<CharacterManager>();

	void Start () {
		Debug.Log("turn order manager");
		findCharacters = FindObjectsOfType<CharacterManager>();
		
		findPlayerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		Debug.Log("player length found is " + findPlayerAllies.Length);
		// add player allies found to List
		for (int i = 0; i < findPlayerAllies.Length; i++) {
			playerAllies.Add(findPlayerAllies[i].GetComponent<CharacterManager>());
		}
		Debug.Log("player count is " + playerAllies.Count);

		findEnemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		Debug.Log("enemy length found is " + findEnemyAllies.Length);
		// add enemy allies found to List
		for (int i = 0; i < findEnemyAllies.Length; i++) {
			enemyAllies.Add(findEnemyAllies[i].GetComponent<CharacterManager>());
		}
		Debug.Log("enemy count is " + enemyAllies.Count);

		for (int i = 0; i < findCharacters.Length; i++) {
			Debug.Log("number " + i + " is " + findCharacters[i]);
			charactersInBattle.Add(findCharacters[i]);
			Debug.Log("characters in battle are " + charactersInBattle[i]);
		}
		Debug.Log("total number of characters found is " + charactersInBattle.Count);

		int characterTurnFirst = Mathf.RoundToInt(Random.Range(0, charactersInBattle.Count));
		Debug.Log("random number is " + characterTurnFirst);
		currentTurn = charactersInBattle[characterTurnFirst];
		currentTurnPosition = characterTurnFirst;

		StartTurn();
	}

	private void StartTurn() {
		Debug.Log("current turn is " + currentTurn);

		// check reset turn position if starting with "last" character
		if (currentTurnPosition >= charactersInBattle.Count) {
			Debug.Log("resetting position");
			currentTurnPosition = 0;
			currentTurn = charactersInBattle[currentTurnPosition];
			currentTurnPosition++;
		}
		else {
			Debug.Log("current position is " + currentTurnPosition + ". which is " + charactersInBattle[currentTurnPosition]);
			currentTurn = charactersInBattle[currentTurnPosition];
			currentTurnPosition++;
		}

		currentTurn.TakeTurn();
	}
	
	public void EndTurn () {
		Debug.Log("ending turn for " + currentTurn + ".");
		StartCoroutine(NextTurn());
	}

	IEnumerator NextTurn() {
		// check reset turn position on each turn
		if (currentTurnPosition >= charactersInBattle.Count) {
			Debug.Log("resetting position");
			currentTurnPosition = 0;

			Debug.Log("current position is " + currentTurnPosition + ". which is " + charactersInBattle[currentTurnPosition]);
			currentTurn = charactersInBattle[currentTurnPosition];
			currentTurnPosition++;
		}
		else {
			Debug.Log("current position is " + currentTurnPosition + ". which is " + charactersInBattle[currentTurnPosition]);
			currentTurn = charactersInBattle[currentTurnPosition];
			currentTurnPosition++;
		}

        yield return new WaitForSeconds(.2f);

		currentTurn.TakeTurn();
	}

	public CharacterManager ChoosePlayerHit() {
		CharacterManager character = playerAllies[Mathf.RoundToInt(Random.Range(0, playerAllies.Count))];
		Debug.Log("player being hit is " + character);

		return character;
	}

	public CharacterManager ChooseEnemyHit() {
		CharacterManager character = enemyAllies[Mathf.RoundToInt(Random.Range(0, enemyAllies.Count))];
		Debug.Log("enemy being hit is " + character);

		return character;
	}

	public void RemoveCharacterTurn(CharacterManager character) {
		Debug.Log("looking to remove " + character.name + " from turn order");
		charactersInBattle.Remove(character);
		for (int i = 0; i < charactersInBattle.Count; i++) {
			Debug.Log("characters left are " + charactersInBattle[i].name);
		}

		// remove from list of characters in battle
		if (character.gameObject.tag == "Player Ally") {
			Debug.Log("removing " + character + " from player list");
			playerAllies.Remove(character);

			for (int i = 0; i < playerAllies.Count; i++) {
				Debug.Log("players left " + playerAllies[i]);
			}
			Debug.Log("player count is " + playerAllies.Count);

			if (playerAllies.Count <= 0) {
				LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
				levelManager.LoadLevel("Lose");
			}
		}
		else if (character.gameObject.tag == "Enemy Ally") {
			Debug.Log("removing " + character + " from enemy list");
			enemyAllies.Remove(character);

			for (int i = 0; i < enemyAllies.Count; i++) {
				Debug.Log("enemies left " + enemyAllies[i]);
			}
			Debug.Log("enemy count is " + enemyAllies.Count);

			if (enemyAllies.Count <= 0) {
				LootManager lootManager = GameObject.Find("LootManager").GetComponent<LootManager>();
				lootManager.EnemyDrops();
				LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
				levelManager.LoadLevel("Win");
			}
		}
	}
}
