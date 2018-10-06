using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

	private bool isWeaponDrop = false;
	private bool isArmorDrop = false;
	private bool isItemDrop = false;
	private string randomElement;
	private string randomMaterial;
	private string randomType;
	private string randomAttributeType;
	private string generatedWeapon;
	private bool presetWeapon;
	private float presetWeaponChance = 10.0f;
	private bool presetArmor;
	private float presetArmorChance = 10.0f;

	public void EnemyDrops() {
        // Debug.Log("checking for enemy drops");
		WeaponGenerator weaponGenerator = gameObject.GetComponent<WeaponGenerator>();
		ArmorGenerator armorGenerator = gameObject.GetComponent<ArmorGenerator>();
		ItemGenerator itemGenerator = gameObject.GetComponent<ItemGenerator>();

		CheckItemDrop();

		if (isWeaponDrop) {
			// check for preset weapon chance
			CheckPresetWeapon();

			weaponGenerator.GenerateWeapon(presetWeapon);
			isWeaponDrop = false;
		}

		if (isArmorDrop) {
			// check for preset armor chance
			CheckPresetArmor();

			armorGenerator.GenerateArmor();
			isArmorDrop = false;
		}

		if (isItemDrop) {
			itemGenerator.GenerateItem();
			isItemDrop = false;
		}
    }

	// need to figure out return type
	// and how I'll set weapon/armor bool's
	// can have factors based on enemy difficulty
	private void CheckItemDrop() {
		Debug.Log("checking chance of item drops");
		isItemDrop = true;
	}

	private bool CheckPresetWeapon() {
		Debug.Log("checking chance of preset weapon");
		Debug.Log("chance of getting Preset Weapon is " + presetWeaponChance);
		float presetWeaponChanceResult = Random.Range(0.0f, 100.0f);
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

	private bool CheckPresetArmor() {
		Debug.Log("checking chance of preset armor");
		Debug.Log("chance of getting Preset Armor is " + presetArmorChance);
		float presetArmorChanceResult = Random.Range(0.0f, 100.0f);
		Debug.Log("outcome is " + presetArmorChanceResult + ".");

		if (presetArmorChanceResult <= 10.0f) {
			Debug.Log("10 or less. Getting preset armor");
			presetArmor = true;
		}
		else {
			presetArmor = false;
		}

		return presetArmor;
	}
}
