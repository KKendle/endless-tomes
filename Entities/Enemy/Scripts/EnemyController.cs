using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int enemyLevel = 1;
    public int enemyStr = 5;
    public int enemyCon = 10;
    private int enemyBaseHealth = 100;
    public int enemyXPValue = 35;
    public int enemyHealthMax;
    // public Sword weapon;

    private int weaponDamage;
    private int damage;
	private EnemyHealth enemyHealth;
    private PlayerController player;
    private PlayerHealth playerHealth;
    // ally
    private PlayerController ally;
    private PlayerHealth allyHealth;

	void Start() {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
        foreach (GameObject ally in allies) {
            Debug.Log(ally);
        }

        playerHealth = GameObject.Find(allies[0].name + "/Canvas/Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            Debug.Log(playerHealth);
            Debug.Log(this + "should have found Player Health");
        }

        player = GameObject.Find(allies[0].name).GetComponent<PlayerController>();
        if (player != null) {
            Debug.Log(player);
            Debug.Log(this + "should have found Player");
        }

        allyHealth = GameObject.Find(allies[1].name + "/Canvas/Health").GetComponent<PlayerHealth>();
        if (allyHealth != null) {
            Debug.Log(allyHealth);
            Debug.Log(this + "should have found Ally Health");
        }

        ally = GameObject.Find(allies[1].name).GetComponent<PlayerController>();
        if (ally != null) {
            Debug.Log(ally);
            Debug.Log(this + "should have found Ally");
        }

        enemyHealthMax = Mathf.RoundToInt(enemyBaseHealth + (enemyCon * 2));

        EnemyHealth.Reset(enemyHealthMax);
	}

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Attack();
		}

        if(EnemyHealth.enemyHealth <= 0) {
            // Debug.Log("Enemy health is zero or below. dying. " + EnemyHealth.enemyHealth);
            Die();
        }
    }

    void Attack() {
        // Debug.Log("Enemy Attacking");
        // weaponDamage = weapon.WeaponDamage();
        weaponDamage  = Mathf.RoundToInt(Random.Range(5, 15)) + (enemyStr / 2);
        // Debug.Log("enemy str " + enemyStr);
        // Debug.Log("enemy rounded " + Mathf.RoundToInt(enemyStr / 2));
        damage = Mathf.RoundToInt(weaponDamage + (enemyStr / 2));
        // Debug.Log("Total enemy damage - rounded " + damage);
        playerHealth.Health(damage);
        // playerHealth.Health(enemyWeapon.GetDamage());
        // Debug.Log("Player health is now at " + PlayerHealth.playerHealth);
    }

	void Die() {
		// Debug.Log("Enemy Died");
		// Destroy(gameObject);
        player.CalculateXP(enemyXPValue);

        // check loot
        LootManager lootManager = GameObject.Find("LootManager").GetComponent<LootManager>();
        lootManager.enemyDrops();

        // next level
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win");
	}
}
