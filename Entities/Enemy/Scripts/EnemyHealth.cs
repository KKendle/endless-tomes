using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	// static means it belongs to class itself, not a created instance of the class
	// meaning, there is only one enemyHealth
	private static int enemyBaseHealth = 100;
	public static int enemyHealth = enemyBaseHealth;
	static EnemyHealth instance = null;

	private static Text healthText;

	void Start() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			healthText = GetComponent<Text>();
			healthText.text = enemyHealth.ToString();
		}
	}

	public void Health(int points) {
		// Debug.Log("Running enemy Health function");
		enemyHealth -= points;
		healthText.text = enemyHealth.ToString();
	}

	public void HealthRestore(int points) {
		enemyHealth += points;
		healthText.text = enemyHealth.ToString();
	}

	public static void Reset() {
		Debug.Log("Enemy health is at " + enemyHealth);
		Debug.Log("Resetting enemy health");
		enemyHealth = enemyBaseHealth;
		healthText.text = enemyHealth.ToString();
		Debug.Log("Enemy health now is at " + enemyHealth);
	}
}
