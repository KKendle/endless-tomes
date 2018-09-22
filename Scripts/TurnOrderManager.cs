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
	private GameObject[] findPlayerAllies;
	private GameObject[] findEnemyAllies;

	// private string[] sampleArray = {"one", "two", "three", "four"};
	// private int sampleArrayPosition = 0;

	void Start () {
		Debug.Log("turn order manager");
		findCharacters = FindObjectsOfType<CharacterManager>();
		findPlayerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		findEnemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		int totalCharacters = findPlayerAllies.Length + findEnemyAllies.Length;

		Debug.Log("total number of characters found is " + findCharacters.Length);
		for (int i = 0; i < findCharacters.Length; i++) {
			Debug.Log("number " + i + " is " + findCharacters[i]);
		}

		// adding "+1" since int max are exclusive
		int characterTurnFirst = Mathf.RoundToInt(Random.Range(0, findCharacters.Length + 1));
		Debug.Log("random number is " + characterTurnFirst);
		currentTurn = findCharacters[characterTurnFirst];
		currentTurnPosition = characterTurnFirst;

		Debug.Log("total characters in battle are " + totalCharacters);
		StartTurn();
	}

	private void StartTurn() {
		Debug.Log("current turn is " + currentTurn);

		// check reset turn position if starting with "last" character
		if (currentTurnPosition >= findCharacters.Length) {
			Debug.Log("resetting position");
			currentTurnPosition = 0;
			currentTurn = findCharacters[currentTurnPosition];
			currentTurnPosition++;
		}
		else {
			Debug.Log("current position is " + currentTurnPosition + ". which is " + findCharacters[currentTurnPosition]);
			currentTurn = findCharacters[currentTurnPosition];
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
		if (currentTurnPosition >= findCharacters.Length) {
			Debug.Log("resetting position");
			currentTurnPosition = 0;
			Debug.Log("current position is " + currentTurnPosition + ". which is " + findCharacters[currentTurnPosition]);
		}
		else {
			Debug.Log("current position is " + currentTurnPosition + ". which is " + findCharacters[currentTurnPosition]);
		}

        yield return new WaitForSeconds(.2f);
		Debug.Log("was " + currentTurn + " turn");

		currentTurn.TakeTurn();
	}

	public void RemoveCharacterTurn(string name) {
		Debug.Log("looking to remove " + name + " from turn order");
	}
}
