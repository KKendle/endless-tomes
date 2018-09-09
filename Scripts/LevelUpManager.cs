using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour {

	private GameObject levelUpInfo;
	private PlayerController player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player != null) {
            // Debug.Log(this + " should have found Player");
        }

		levelUpInfo = GameObject.Find("Level Up Info");
		if (levelUpInfo != null) {
			Debug.Log(this + " should have found Level Up Info");
		}
		HideLevelUpScreen();

		// Debug.Log(this + " says player xp is " + player.playerXP);
		// CheckLvlUp(player.playerXP);
	}

	void ShowLevelUpScreen() {
		// show level up information
		// text.gameObject.SetActive(boolean)
		levelUpInfo.SetActive(true);
	}

	void HideLevelUpScreen() {
		// hide level up information
		// text.gameObject.SetActive(boolean)
		levelUpInfo.SetActive(false);
	}

	public void StrengthIncrease() {
        Debug.Log("increasing player strength");
        Debug.Log("player strength is " + player.playerStr);
        player.playerStr++;
        Debug.Log("player strength is now " + player.playerStr);
		GameObject.Find("Level Up Info").SetActive(false);
    }

    public void ConstitutionIncrease() {
        Debug.Log("increasing player constitution");
        Debug.Log("player constitution is " + player.playerCon);
        player.playerCon++;
        Debug.Log("player constitution is now " + player.playerCon);
		GameObject.Find("Level Up Info").SetActive(false);
    }

	// public void CalculateXP(string name, int xp) {
	// 	Debug.Log("running CalculateXP from " + this);
	// 	Debug.Log("xp received is " + xp);
	// 	PlayerController ally = GameObject.Find(name).GetComponent<PlayerController>();
    //     // // show experience points of player
	// 	// Debug.Log(name + "/Canvas/Experience");
    //     // Text playerXPText = transform.Find(name + "Canvas/Experience").GetComponent<Text>();

    //     Debug.Log("Current XP for " + this + " is " + ally.playerXP);
    //     Debug.Log("XP gained " + xp);
    //     Debug.Log("Calculating XP");
    //     ally.playerXP += xp;
	// 	Debug.Log(PlayerPrefs.GetInt("PlayerCharXP"));
	// 	PlayerPrefs.SetInt("PlayerCharXP", PlayerPrefs.GetInt("PlayerCharXP") + xp);
	// 	Debug.Log(PlayerPrefs.GetInt("PlayerCharXP"));
    //     Debug.Log("Current XP for " + this + " is " + ally.playerXP);
    //     // playerXPText.text = "XP " + ally.playerXP + "/" + ally.playerXPNextLevel;
    // }

	public void CheckLvlUp(string name, int currentXP) {
		Debug.Log(name + " level is " + PlayerPrefs.GetInt(name + " level"));
		Debug.Log("calculating if there is a lvl up");
		if (currentXP >= 83 && PlayerPrefs.GetInt(name + " level") < 2) {
			Debug.Log("you lvl up");
			PlayerPrefs.SetInt(name + " level", PlayerPrefs.GetInt(name + " level") + 1);
			Debug.Log(name + " level is now " + PlayerPrefs.GetInt(name + " level"));
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 174 && PlayerPrefs.GetInt(name + " level") < 3) {
			Debug.Log("you lvl up");
			PlayerPrefs.SetInt(name + " level", PlayerPrefs.GetInt(name + " level") + 1);
			Debug.Log("player level is now " + PlayerPrefs.GetInt(name + " level"));
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 276 && PlayerPrefs.GetInt(name + " level") < 4) {
			Debug.Log("you lvl up");
			PlayerPrefs.SetInt(name + " level", PlayerPrefs.GetInt(name + " level") + 1);
			Debug.Log("player level is now " + PlayerPrefs.GetInt(name + " level"));
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 388 && PlayerPrefs.GetInt(name + " level") < 5) {
			Debug.Log("you lvl up");
			PlayerPrefs.SetInt(name + " level", PlayerPrefs.GetInt(name + " level") + 1);
			Debug.Log("player level is now " + PlayerPrefs.GetInt(name + " level"));
			AbilityLevelUp(5);
			ShowLevelUpScreen();
		}
		else {
			Debug.Log("no lvl up");
		}
	}

	void AbilityLevelUp(int modifier) {
		if (player.playerLevel == 2) {
			Debug.Log("player constitution is " + player.playerCon);
			player.playerCon += modifier;
			Debug.Log("player constitution is now " + player.playerCon);

			Debug.Log("player strength is " + player.playerStr);
			player.playerStr += modifier;
			Debug.Log("player strength is now " + player.playerStr);
		}
		if (player.playerLevel == 3) {
			Debug.Log("player constitution is " + player.playerCon);
			player.playerCon += modifier;
			Debug.Log("player constitution is now " + player.playerCon);

			Debug.Log("player strength is " + player.playerStr);
			player.playerStr += modifier;
			Debug.Log("player strength is now " + player.playerStr);
		}
		if (player.playerLevel == 4) {
			Debug.Log("player constitution is " + player.playerCon);
			player.playerCon += modifier;
			Debug.Log("player constitution is now " + player.playerCon);

			Debug.Log("player strength is " + player.playerStr);
			player.playerStr += modifier;
			Debug.Log("player strength is now " + player.playerStr);
		}
		if (player.playerLevel == 5) {
			Debug.Log("player constitution is " + player.playerCon);
			player.playerCon += modifier;
			Debug.Log("player constitution is now " + player.playerCon);

			Debug.Log("player strength is " + player.playerStr);
			player.playerStr += modifier;
			Debug.Log("player strength is now " + player.playerStr);
		}
	}
}
