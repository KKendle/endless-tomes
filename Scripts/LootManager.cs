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

	public void enemyDrops() {
        // Debug.Log("checking for enemy drops");
		WeaponGenerator weaponGenerator = gameObject.GetComponent<WeaponGenerator>();
		ArmorGenerator armorGenerator = gameObject.GetComponent<ArmorGenerator>();

		if (isWeaponDrop) {
			weaponGenerator.generateWeapon();
			isWeaponDrop = false;
		}

		if (isArmorDrop) {
			armorGenerator.generateArmor();
			isArmorDrop = false;
		}
    }
}
