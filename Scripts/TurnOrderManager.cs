using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderManager : MonoBehaviour {

	private string currentTurn;
	private bool alliesTurn = false;
	private bool enemiesTurn = false;
	private int allyTurnCount = 0;
	private int enemyTurnCount = 0;
	private GameObject[] findPlayerAllies;
	private GameObject[] findEnemyAllies;

	private string[] sampleArray = {"one", "two", "three", "four"};
	private int sampleArrayPosition = 0;

	void Start () {
		Debug.Log("turn order manager");
		findPlayerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		findEnemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		int totalCharacters = findPlayerAllies.Length + findEnemyAllies.Length;


		Debug.Log("sample array is " + sampleArray.Length);

		for (int i = 0; i < sampleArray.Length; i++) {
			Debug.Log(i + " is " + sampleArray[i]);
		}

		int playerOrEnemyTurnFirst = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
		if (playerOrEnemyTurnFirst == 0) {
			Debug.Log("player going first");
			alliesTurn = true;
			// random choose starting ally to start
			int allyTurn = Mathf.RoundToInt(Random.Range(0, findPlayerAllies.Length));
			currentTurn = findPlayerAllies[allyTurn].name;
		}
		else if (playerOrEnemyTurnFirst == 1) {
			Debug.Log("enemy going first");
			enemiesTurn = true;
			// random choose starting enemy to start
			int enemyTurn = Mathf.RoundToInt(Random.Range(0, findEnemyAllies.Length));
			currentTurn = findEnemyAllies[enemyTurn].name;
		}
		else {
			Debug.Log("no idea who's going first");
		}

		Debug.Log("total characters in battle are " + totalCharacters);
		StartTurn();
	}

	private void StartTurn() {
		Debug.Log("current turn is " + currentTurn);

		if (sampleArrayPosition >= sampleArray.Length) {
			Debug.Log("resetting position");
			sampleArrayPosition = 0;
		}
		else {
			Debug.Log("current position is " + sampleArrayPosition + ". which is " + sampleArray[sampleArrayPosition]);
			sampleArrayPosition++;
		}

		if (alliesTurn) {
			allyTurnCount++;
			CharacterManager playerTurn = GameObject.Find(currentTurn).GetComponent<CharacterManager>();
			playerTurn.TakeTurn();
		}
		else if (enemiesTurn) {
			enemyTurnCount++;
			CharacterManager enemyTurn = GameObject.Find(currentTurn).GetComponent<CharacterManager>();
			enemyTurn.TakeTurn();
		}
	}
	
	public void EndTurn () {
		Debug.Log("ending turn for " + currentTurn + ".");
		StartCoroutine(NextTurn());
	}

	IEnumerator NextTurn() {
		if (sampleArrayPosition >= sampleArray.Length) {
			Debug.Log("resetting position");
			sampleArrayPosition = 0;
		}
		else {
			Debug.Log("current position is " + sampleArrayPosition + ". which is " + sampleArray[sampleArrayPosition]);
			sampleArrayPosition++;
		}
		// temp faking next turn
        yield return new WaitForSeconds(.2f);
		Debug.Log("was " + currentTurn + " turn");

		if (alliesTurn) {
			AllyTurn();
		}
		else if (enemiesTurn) {
			EnemyTurn();
		}
		else {
			Debug.Log("not sure who's turn it was");
		}
	}

	private void AllyTurn() {
		if (currentTurn == "Ally1") {
			currentTurn = "Player";
		}
		else if (currentTurn == "Player") {
			currentTurn = "Ally1";
		}
		// for swapping between enemy and player
		else if (currentTurn == "Enemy" || currentTurn == "Enemy (1)") {
			currentTurn = "Player";
		}
		Debug.Log("current turn is " + currentTurn);
		CharacterManager playerTurn = GameObject.Find(currentTurn).GetComponent<CharacterManager>();
		playerTurn.TakeTurn();
		allyTurnCount++;
		Debug.Log("ally turn count is " + allyTurnCount + ".");
		if (allyTurnCount >= 2) {
			alliesTurn = false;
			enemiesTurn = true;

			// reset for continued play
			allyTurnCount = 0;
		}
	}

	private void EnemyTurn() {
		if (currentTurn == "Enemy") {
			currentTurn = "Enemy (1)";
		}
		else if (currentTurn == "Enemy (1)") {
			currentTurn = "Enemy";
		}
		// for swapping from player to enemy
		else if (currentTurn == "Player" || currentTurn == "Ally1") {
			currentTurn = "Enemy";
		}
		Debug.Log("current turn is " + currentTurn);
		CharacterManager enemyTurn = GameObject.Find(currentTurn).GetComponent<CharacterManager>();
		enemyTurn.TakeTurn();
		enemyTurnCount++;
		Debug.Log("enemy turn count is " + enemyTurnCount + ".");
		if (enemyTurnCount >= 2) {
			enemiesTurn = false;
			alliesTurn = true;

			// reset for continued play
			enemyTurnCount = 0;
		}
	}
}
