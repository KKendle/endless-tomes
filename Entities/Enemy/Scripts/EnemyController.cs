using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int enemyLevel = 1;
    public int enemyStr = 5;
    public int enemyCon = 10;
    public int enemyXPValue = 35;
    public Sword weapon;

    private int weaponDamage;
    private int damage;
	private EnemyHealth enemyHealth;
    private PlayerController player;
    private PlayerHealth playerHealth;


	void Start() {
        Debug.Log("Enemy Health");
        playerHealth = GameObject.Find("Player Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            Debug.Log("should have found Player Health");
        }

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player != null) {
            Debug.Log("should have found Player");
        }

        EnemyHealth.Reset();
	}

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Attack();
		}

        if(EnemyHealth.enemyHealth <= 0) {
            Debug.Log("Enemy health is zero or below. dying. " + EnemyHealth.enemyHealth);
            Die();
        }
    }

    void Attack() {
        // Debug.Log("Enemy Attacking");
        weaponDamage = weapon.WeaponDamage();
        Debug.Log("enemy str " + enemyStr);
        Debug.Log("enemy rounded " + Mathf.RoundToInt(enemyStr / 2));
        damage = Mathf.RoundToInt(weaponDamage + (enemyStr / 2));
        Debug.Log("Total enemy damage - rounded " + damage);
        playerHealth.Health(damage);
        // playerHealth.Health(enemyWeapon.GetDamage());
        // Debug.Log("Player health is now at " + PlayerHealth.playerHealth);
    }

	void Die() {
		Debug.Log("Enemy Died");
		// Destroy(gameObject);
        player.CalculateXP(enemyXPValue);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win");
	}
}
