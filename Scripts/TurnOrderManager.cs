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

	void Start () {
		Debug.Log("turn order manager");
		findPlayerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		findEnemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		int totalCharacters = findPlayerAllies.Length + findEnemyAllies.Length;

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
		if (alliesTurn) {
			allyTurnCount++;
			PlayerController playerTurn = GameObject.Find(currentTurn).GetComponent<PlayerController>();
			playerTurn.TakeTurn();
		}
		else if (enemiesTurn) {
			enemyTurnCount++;
			EnemyController enemyTurn = GameObject.Find(currentTurn).GetComponent<EnemyController>();
			enemyTurn.TakeTurn();
		}
	}
	
	public void EndTurn () {
		Debug.Log("ending turn for " + currentTurn + ".");
		StartCoroutine(NextTurn());
	}

	IEnumerator NextTurn() {
		// temp faking next turn
        yield return new WaitForSeconds(1);
		Debug.Log("was " + currentTurn + " turn");

		if (alliesTurn) {
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
			PlayerController playerTurn = GameObject.Find(currentTurn).GetComponent<PlayerController>();
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
		else if (enemiesTurn) {
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
			EnemyController enemyTurn = GameObject.Find(currentTurn).GetComponent<EnemyController>();
			enemyTurn.TakeTurn();
			enemyTurnCount++;
			Debug.Log("enemy turn count is + " + enemyTurnCount + ".");
			if (enemyTurnCount >= 2) {
				enemiesTurn = false;
				alliesTurn = true;

				// reset for continued play
				enemyTurnCount = 0;
			}
		}
		else {
			Debug.Log("not sure who's turn it was");
		}
	}
}
