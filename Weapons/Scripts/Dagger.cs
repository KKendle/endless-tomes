using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {

	public float damageMin = 6.0f;
	public float damageMax = 8.0f;
	public int baseStr = 1;

	private int damage;

	public int WeaponDamage() {
		Debug.Log("running dagger weapon damage");
		damage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		Debug.Log("dagger damage " + damage);
		return damage;
	}
}
