using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public string weaponName;
	public string weaponType;
	public float weaponDamageMin;
	public float weaponDamageMax;
	public int weaponStr;
	public int weaponCon;
	public int weaponDex;
	public int weaponInt;
	public int weaponWis;
	public int weaponHeal;
	public string weaponElement;
	public string weaponMaterial;
	public string weaponAttributeType;

	public int WeaponDamage(string currentWeapon) {
		int damage = 0;

		Debug.Log("running weapon damage");
		Debug.Log("weapon name is " + weaponName);
		Debug.Log("current weapon is " + currentWeapon);
		// damage = sword.WeaponDamage();
		// Debug.Log(damage + " damage");
		// damage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		// Debug.Log("sword damage " + damage);
		switch (currentWeapon.ToLower()) {
			case "sword":
				Debug.Log("sword equipped");
				damage = getSwordDamage();
				break;
			case "dagger":
				Debug.Log("dagger equipped");
				damage = getDaggerDamage();
				break;
			
			default:
				Debug.Log("no weapon equipped");
				break;
		}
		return damage;
	}

	private int getSwordDamage() {
		Debug.Log("getting sword damage");
		float damageMin = 10.0f;
		float damageMax = 12.0f;
		int baseStr = 1;

		int swordDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		Debug.Log(swordDamage);
		Debug.Log(weaponStr);
		swordDamage += weaponStr;
		Debug.Log(swordDamage);

		return swordDamage;
	}

	private int getDaggerDamage() {
		Debug.Log("getting dagger damage");
		float damageMin = 6.0f;
		float damageMax = 8.0f;
		int baseStr = 1;

		int daggerDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		// int daggerDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)));

		return daggerDamage;
	}
}
