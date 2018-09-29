using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Weapon SetStartingWeapon() {
        WeaponGenerator weaponGenerator = GameObject.Find("LootManager").GetComponent<WeaponGenerator>();
		string randomWeaponType = weaponGenerator.GenerateType();

		Weapon weaponEquipped = transform.Find("Equipped/Weapon").GetComponent<Weapon>();
		weaponEquipped.SetWeaponType(randomWeaponType);
        weaponGenerator.GetBaseStats(weaponEquipped);

        return weaponEquipped;
    }

    // public void SetStartingArmor() {
    //     SetHelmet();
    //     SetChestplate();
    //     SetBracers();
    //     SetLegs();
    //     SetBoots();
    // }

    public Armor SetHelm() {
        Debug.Log("running set helm");
        ArmorGenerator armorGenerator = GameObject.Find("LootManager").GetComponent<ArmorGenerator>();
        Armor armor = transform.Find("Equipped/Helm").GetComponent<Armor>();
        armorGenerator.GetBaseStats(armor);

        return armor;
    }

    public Armor SetChestplate() {
        Debug.Log("running set chestplate");
        ArmorGenerator armorGenerator = GameObject.Find("LootManager").GetComponent<ArmorGenerator>();
        Armor armor = transform.Find("Equipped/Chestplate").GetComponent<Armor>();
        armorGenerator.GetBaseStats(armor);

        return armor;
    }

    public Armor SetBracers() {
        Debug.Log("running set bracers");
        ArmorGenerator armorGenerator = GameObject.Find("LootManager").GetComponent<ArmorGenerator>();
        Armor armor = transform.Find("Equipped/Bracers").GetComponent<Armor>();
        armorGenerator.GetBaseStats(armor);

        return armor;
    }

    public Armor SetLegs() {
        Debug.Log("running set legs");
        ArmorGenerator armorGenerator = GameObject.Find("LootManager").GetComponent<ArmorGenerator>();
        Armor armor = transform.Find("Equipped/Legs").GetComponent<Armor>();
        armorGenerator.GetBaseStats(armor);

        return armor;
    }

    public Armor SetBoots() {
        Debug.Log("running set boots");
        ArmorGenerator armorGenerator = GameObject.Find("LootManager").GetComponent<ArmorGenerator>();
        Armor armor = transform.Find("Equipped/Boots").GetComponent<Armor>();
        armorGenerator.GetBaseStats(armor);

        return armor;
    }
}
