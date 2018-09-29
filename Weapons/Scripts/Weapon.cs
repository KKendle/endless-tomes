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

	public int WeaponDamage(CharacterManager character) {
		int damage = 0;
		damage = (Mathf.RoundToInt(Random.Range(weaponDamageMin, weaponDamageMax)) + (character.characterStr / 2));

		return damage;
	}
}
