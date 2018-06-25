using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

	private int baseDamage = 5;

	private EnemyController enemy;

	void Start() {
		enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
        if (enemy != null) {
            Debug.Log("should have found Enemy");
        }
	}

	public int GetDamage() {
		// Debug.Log("Damage of " + damage);
		// Debug.Log("damage of " + baseDamage + " and str of " + enemy.enemyStr);
        int additionalDamage = Mathf.RoundToInt(Random.Range(0.0f, 2.0f));
        Debug.Log("additional damage of " + additionalDamage);
		int modifiedDamage = baseDamage + enemy.enemyStr + additionalDamage;
		Debug.Log("modDamage " + modifiedDamage);
		return modifiedDamage;
	}
}
