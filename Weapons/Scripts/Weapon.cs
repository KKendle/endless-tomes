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
	public string weaponDescription;
	public string weaponEffect;

	// public int WeaponDamage() {
	// 	int damage = 0;
	// 	Debug.Log("running weapon damage");
	// 	damage = (Mathf.RoundToInt(Random.Range(weaponDamageMin, weaponDamageMax)) + (weaponStr / 2));
	// 	Debug.Log("damage is " + damage);

	// 	return damage;
	// }

	public int WeaponDamage(string currentWeaponType) {
		int damage = 0;

		Debug.Log("running weapon damage");
		Debug.Log("weapon name is " + weaponName);
		Debug.Log("current weapon is " + currentWeaponType);
		// damage = sword.WeaponDamage();
		// Debug.Log(damage + " damage");
		// damage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));
		// Debug.Log("sword damage " + damage);
		switch (currentWeaponType.ToLower()) {
			case "sword":
				Debug.Log("sword equipped");
				damage = GetSwordDamage();
				break;

			case "dagger":
				Debug.Log("dagger equipped");
				damage = GetDaggerDamage();
				break;

			case "mace":
				Debug.Log("mace equipped");
				damage = GetMaceDamage();
				break;

			case "battleaxe":
				Debug.Log("battleaxe equipped");
				damage = GetBattleAxeDamage();
				break;
			
			default:
				Debug.Log("no weapon equipped");
				break;
		}
		return damage;
	}

	private int GetSwordDamage() {
		Debug.Log("getting sword damage");
		float damageMin = 10.0f;
		float damageMax = 16.0f;
		int baseStr = 4;

		int swordDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));

		return swordDamage;
	}

	private int GetDaggerDamage() {
		Debug.Log("getting dagger damage");
		float damageMin = 6.0f;
		float damageMax = 10.0f;
		int baseStr = 2;

		int daggerDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));

		return daggerDamage;
	}

	private int GetMaceDamage() {
		Debug.Log("getting mace damage");
		float damageMin = 8.0f;
		float damageMax = 14.0f;
		int baseStr = 3;

		int maceDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));

		return maceDamage;
	}

	private int GetBattleAxeDamage() {
		Debug.Log("getting battleaxe damage");
		float damageMin = 14.0f;
		float damageMax = 20.0f;
		int baseStr = 6;

		int battleAxeDamage = (Mathf.RoundToInt(Random.Range(damageMin, damageMax)) + (baseStr / 2));

		return battleAxeDamage;
	}
}
