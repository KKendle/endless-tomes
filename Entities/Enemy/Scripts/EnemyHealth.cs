using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	// // static means it belongs to class itself, not a created instance of the class
	// // meaning, there is only one enemyHealth
	// // static EnemyHealth instance = null;
	// // public int enemyHealth;

	// private EnemyController enemy;
	// private Text healthText;

	// void Awake() {
	// 	// if (instance != null && instance != this) {
	// 	// 	Destroy(gameObject);
	// 	// }
	// 	// else {
	// 	// 	instance = this;
	// 	// 	GameObject.DontDestroyOnLoad(gameObject);
	// 	// 	healthText = GetComponent<Text>();
	// 	// 	// healthText.text = enemyHealth.ToString();
	// 	// }
	// 	enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
	// 	if (enemy != null) {
	// 		Debug.Log("enemy should have found the Enemy Controller component");
	// 	}

	// 	healthText = GetComponent<Text>();
	// 	if (healthText != null) {
	// 		Debug.Log("healthText should have found the Text component");
	// 	}
	// }

	// public void Health(string name, int points) {
	// 	EnemyController enemy = GameObject.Find(name).GetComponent<EnemyController>();
	// 	enemy.enemyHealthCurrent -= points;
	// 	healthText.text = "HP " + enemy.enemyHealthCurrent + "/" + enemy.enemyHealthMax;
	// }

	// public void HealthRestore(string name, int points) {
	// 	EnemyController enemy = GameObject.Find(name).GetComponent<EnemyController>();
	// 	enemy.enemyHealthCurrent += points;
	// 	healthText.text = "HP " + enemy.enemyHealthCurrent + "/" + enemy.enemyHealthMax;
	// }

	// public void Reset(string name) {
	// 	Debug.Log("Resetting enemy health");
	// 	EnemyController enemy = GameObject.Find(name).GetComponent<EnemyController>();
	// 	enemy.enemyHealthCurrent = enemy.enemyHealthMax;
	// 	healthText.text = "HP " + enemy.enemyHealthCurrent + "/" + enemy.enemyHealthMax;
	// }
}
