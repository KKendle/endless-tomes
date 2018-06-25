using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	private int baseDamage = 10;
	public Sword weapon;

	// private PlayerController player;

	void Start() {
		// player = GameObject.Find("Player").GetComponent<PlayerController>();
        // if (player != null) {
        //     Debug.Log("should have found Player");
        // }
		Debug.Log("weapon is " + weapon);
	}

	public int GetDamage() {
		// Debug.Log("base weapon damage " + weapon);
		return weapon.WeaponDamage();
	}

	// public int GetDamage() {
	// 	// Debug.Log("Damage of " + damage);
	// 	// Debug.Log("damage of " + baseDamage + " and str of " + player.playerStr);
    //     int additionalDamage = Mathf.RoundToInt(Random.Range(0.0f, 2.0f));
    //     Debug.Log("additional damage of " + additionalDamage);
	// 	int modifiedDamage = baseDamage + player.playerStr + additionalDamage;
	// 	Debug.Log("modDamage " + modifiedDamage);
	// 	return modifiedDamage;
	// }
}
