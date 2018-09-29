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
}
