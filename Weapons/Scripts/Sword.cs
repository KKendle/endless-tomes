using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float damageMin = 10.0f;
	public float damageMax = 12.0f;
	public int baseStr = 1;

	private int damage;

	public int WeaponDamage() {
		// Debug.Log("running sword weapon damage");
		damage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		// Debug.Log("sword damage " + damage);
		return damage;
	}
}
