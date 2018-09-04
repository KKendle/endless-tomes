using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// static means it belongs to class itself, not a created instance of the class
	// meaning, there is only one playerHealth
	// static PlayerHealth instance = null;

	private Text healthText;
	private PlayerController player;
	private string health;

	void Start() {
		Debug.Log("running start of " + this);
		// if (instance != null && instance != this) {
		// 	Destroy(gameObject);
		// }
		// else {
		// 	instance = this;
		// 	GameObject.DontDestroyOnLoad(gameObject);
		// 	healthText = GetComponent<Text>();
		// 	healthText.text = playerHealth.ToString();
		// }
		healthText = GetComponent<Text>();
		if (healthText != null) {
			Debug.Log("healthText should have found the Text component");
		}
		// Debug.Log("healthText text is " + healthText.text);
		// healthText.text = health;
		// Debug.Log("healthText text is " + healthText.text);
		// player = GameObject.Find("Player").GetComponent<PlayerController>();
        // if (player != null) {
        //     Debug.Log(this + "should have found Player");
        // }
	}

	public void Health(string name, int points) {
		Debug.Log("Running player Health function");
		PlayerController character = GameObject.Find(name).GetComponent<PlayerController>();
		Debug.Log(character);
		Debug.Log("Player health is at " + character.playerHealthCurrent);
		character.playerHealthCurrent -= points;
		Debug.Log("Player health now is at " + character.playerHealthCurrent);
		healthText.text = "HP " + character.playerHealthCurrent + "/" + character.playerHealthMax;;
	}

	public void HealthRestore(string name, int points) {
		PlayerController character = GameObject.Find(name).GetComponent<PlayerController>();
		Debug.Log(character);
		Debug.Log("Player health is at " + character.playerHealthCurrent);
		character.playerHealthCurrent += points;
		Debug.Log("Player health now is at " + character.playerHealthCurrent);
		healthText.text = "HP " + character.playerHealthCurrent + "/" + character.playerHealthMax;
	}

	public void Reset(string name) {
		Debug.Log("running health reset for " + name);
		PlayerController character = GameObject.Find(name).GetComponent<PlayerController>();
		Debug.Log(character);
		// gets max health of player
        character.playerHealthMax = Mathf.RoundToInt(character.playerBaseHealth + (character.playerCon * 2));
        // current health starts as max health
        character.playerHealthCurrent = character.playerHealthMax;
		// calculate player health
		health = "HP " + character.playerHealthCurrent + "/" + character.playerHealthMax;

		Debug.Log(name + " health is at " + character.playerHealthCurrent);
		Debug.Log("Resetting " + name + " health");
		healthText.text = health;
		Debug.Log(name + " health now is at " + character.playerHealthCurrent);
	}
}
