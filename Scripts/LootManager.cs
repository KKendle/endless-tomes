using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

	private bool isWeaponDrop = true;
	private bool isArmorDrop = true;
	private string randomElement;
	private string randomMaterial;
	private string randomType;
	private string randomAttributeType;
	private string generatedWeapon;
	private bool presetWeapon;
	private float presetWeaponChance = 10.0f;
	private float presetWeaponChanceResult;

	public void enemyDrops() {
        // Debug.Log("checking for enemy drops");
		WeaponGenerator weaponGenerator = gameObject.GetComponent<WeaponGenerator>();
		ArmorGenerator armorGenerator = gameObject.GetComponent<ArmorGenerator>();

		// check for preset weapon chance
		checkPresetWeapon();

		if (isWeaponDrop) {
			weaponGenerator.generateWeapon(presetWeapon);
			isWeaponDrop = false;
		}

		if (isArmorDrop) {
			armorGenerator.generateArmor();
			isArmorDrop = false;
		}
    }

	private bool checkPresetWeapon() {
		Debug.Log("checking chance of preset weapon");
		Debug.Log("chance of getting Preset Weapon is " + presetWeaponChance);
		presetWeaponChanceResult = Random.Range(0.0f, 100.0f);
		Debug.Log("outcome is " + presetWeaponChanceResult + ".");

		if (presetWeaponChanceResult <= 10.0f) {
			Debug.Log("10 or less. Getting preset weapon");
			presetWeapon = true;
		}
		else {
			presetWeapon = false;
		}

		return presetWeapon;
	}
}
