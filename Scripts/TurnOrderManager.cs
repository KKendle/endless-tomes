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
	private GameObject[] findEnemyAllies;

	void Start () {
		Debug.Log("turn order manager");
		findCharacters = FindObjectsOfType<CharacterManager>();
		findPlayerAllies = GameObject.FindGameObjectsWithTag("Player Ally");
		findEnemyAllies = GameObject.FindGameObjectsWithTag("Enemy Ally");
		int totalCharacters = findPlayerAllies.Length + findEnemyAllies.Length;

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

		Debug.Log("total characters in battle are " + totalCharacters);
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

	public void RemoveCharacterTurn(string name) {
		Debug.Log("looking to remove " + name + " from turn order");
		for (int i = 0; i < charactersInBattle.Count; i++) {
			if (name == charactersInBattle[i].name) {
				Debug.Log("found character to remove at " + i);
				charactersInBattle.Remove(charactersInBattle[i]);
				break;
			}
			else {
				Debug.Log("did not find character to remove");
			}
		}
	}
}
