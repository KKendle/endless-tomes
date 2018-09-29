using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private GameObject lootManager;
    private WeaponGenerator weaponGenerator;
    private ArmorGenerator armorGenerator;
    // private ItemGenerator itemGenerator;

    void Start() {
        lootManager = GameObject.Find("LootManager");
        armorGenerator = lootManager.GetComponent<ArmorGenerator>();
        weaponGenerator = lootManager.GetComponent<WeaponGenerator>();
        // itemGenerator = lootManager.GetComponent<ItemGenerator>();
    }

    public Weapon SetStartingWeapon() {
		string randomWeaponType = weaponGenerator.GenerateType();

		Weapon weaponEquipped = transform.Find("Equipped/Weapon").GetComponent<Weapon>();
		weaponEquipped.weaponType = randomWeaponType;
        weaponEquipped.weaponName = randomWeaponType;
        weaponGenerator.GetBaseStats(weaponEquipped);

        return weaponEquipped;
    }

    public Armor SetHelm() {
        Debug.Log("running set helm");
        Armor armor = transform.Find("Equipped/Helm").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetShoulders() {
        Debug.Log("running set shoulders");
        Armor armor = transform.Find("Equipped/Shoulders").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetChestplate() {
        Debug.Log("running set chestplate");
        Armor armor = transform.Find("Equipped/Chestplate").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetBracers() {
        Debug.Log("running set bracers");
        Armor armor = transform.Find("Equipped/Bracers").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetGloves() {
        Debug.Log("running set gloves");
        Armor armor = transform.Find("Equipped/Gloves").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetLegs() {
        Debug.Log("running set legs");
        Armor armor = transform.Find("Equipped/Legs").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }

    public Armor SetBoots() {
        Debug.Log("running set boots");
        Armor armor = transform.Find("Equipped/Boots").GetComponent<Armor>();
        
        int armorChance = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        if (armorChance >= 5) {
            armorGenerator.GetBaseStats(armor);
        }

        return armor;
    }
}
