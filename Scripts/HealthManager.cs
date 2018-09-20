using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	private Text healthText;
	private string health;

	void Awake() {
		Debug.Log("running start of Health Manager for " + this);

		// find health text
		healthText = GetComponent<Text>();
		if (healthText != null) {
			Debug.Log("health text should have found the Text component");
		}
	}

	public void Health(string name, int points) {
		Debug.Log("running health function for " + name);
		CharacterManager character = GameObject.Find(name).GetComponent<CharacterManager>();
		Debug.Log(character.name + " health is at " + character.characterHealthCurrent);

		// damage taken
		character.characterHealthCurrent -= points;
		Debug.Log(character.name + " health is now at " + character.characterHealthCurrent);

		// set health in UI
		healthText.text = "HP " + character.characterHealthCurrent + "/" + character.characterHealthMax;
	}

	// add HealthRestore later
	// not currently used

	public void Reset(string name) {
		Debug.Log("running health reset for " + name);
		CharacterManager character = GameObject.Find(name).GetComponent<CharacterManager>();
		Debug.Log("character is " + character);

		// set current health to max health
		character.characterHealthCurrent = character.characterHealthMax;
		
		// set health in UI
		healthText.text = "HP " + character.characterHealthCurrent + "/" + character.characterHealthMax;
	}
}
