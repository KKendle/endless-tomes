using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// static means it belongs to class itself, not a created instance of the class
	// meaning, there is only one playerHealth
	private static int playerBaseHealth = 100;
	public static int playerHealth = playerBaseHealth;
	static PlayerHealth instance = null;

	private static Text healthText;

	void Start() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			healthText = GetComponent<Text>();
			healthText.text = playerHealth.ToString();
		}
	}

	// public void InitialHealth(int health) {
	// 	Debug.Log("running initial health");
	// 	healthText.text = playerHealth.ToString();
	// }

	public void Health(int points) {
		// Debug.Log("Running player Health function");
		playerHealth -= points;
		healthText.text = playerHealth.ToString();
	}

	public void HealthRestore(int points) {
		playerHealth += points;
		healthText.text = playerHealth.ToString();
	}

	public static void Reset() {
		Debug.Log("Player health is at " + playerHealth);
		Debug.Log("Resetting player health");
		playerHealth = playerBaseHealth;
		healthText.text = playerHealth.ToString();
		Debug.Log("Player health now is at " + playerHealth);
	}
}
