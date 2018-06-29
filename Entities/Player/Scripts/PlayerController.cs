using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int playerLevel = 1;
    public static int playerXP = 0;
    public static int playerStr = 10;
    public static int playerCon = 10;
    public static int playerBaseHealth = 100;
    public static int playerHealthMax;
    public Sword weapon;

    private int weaponDamage;
    private int damage;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private static Text playerLevelText;
    private static Text playerXPText;

	void Start() {
        playerHealth = GameObject.Find("Player Health").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            // Debug.Log(this + "should have found Player Health");
        }

        enemyHealth = GameObject.Find("Enemy Health").GetComponent<EnemyHealth>();
        if (enemyHealth != null) {
            // Debug.Log(this + "should have found Enemy Health");
        }

        playerHealthMax = Mathf.RoundToInt(playerBaseHealth + (playerCon * 2));

        playerLevelText = GameObject.Find("Player Level").GetComponent<Text>();
        playerLevelText.text = playerLevel.ToString();

        playerXPText = GameObject.Find("Player XP").GetComponent<Text>();
        playerXPText.text = playerXP.ToString();

        PlayerHealth.Reset();
	}

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Attack();
		}

        if(PlayerHealth.playerHealth <= 0) {
            Debug.Log("Player health is zero or below. dying. " + PlayerHealth.playerHealth);
            Die();
        }
    }

    void Attack() {
        // Debug.Log("Player attacking");
        weaponDamage = weapon.WeaponDamage();
        damage = Mathf.RoundToInt(weaponDamage + (playerStr / 2));
        // Debug.Log("player str " + playerStr);
        // Debug.Log("total player damage " + damage);
        enemyHealth.Health(damage);
        // Debug.Log("Enemy health is now at " + EnemyHealth.enemyHealth);
    }

    public void CalculateXP(int xp) {
        Debug.Log("Current XP " + playerXP);
        Debug.Log("XP gained " + xp);
        Debug.Log("Calculating XP");
        playerXP += xp;
        Debug.Log("Current XP " + playerXP);
    }

	void Die() {
		Debug.Log("Player Died");
		// Destroy(gameObject);
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}
