using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour {

	public GameObject levelUpInfo;

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

		Debug.Log(this + " says player xp is " + player.playerXP);
		CheckLvlUp(player.playerXP);
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

	void CheckLvlUp(int currentXP) {
		Debug.Log("player level is " + player.playerLevel);
		Debug.Log("calculating if there is a lvl up");
		if (currentXP >= 83 && player.playerLevel < 2) {
			Debug.Log("you lvl up");
			player.playerLevel++;
			Debug.Log("player level is now " + player.playerLevel);
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 174 && player.playerLevel < 3) {
			Debug.Log("you lvl up");
			player.playerLevel++;
			Debug.Log("player level is now " + player.playerLevel);
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 276 && player.playerLevel < 4) {
			Debug.Log("you lvl up");
			player.playerLevel++;
			Debug.Log("player level is now " + player.playerLevel);
			AbilityLevelUp(2);
			ShowLevelUpScreen();
		}
		if (currentXP >= 388 && player.playerLevel < 5) {
			Debug.Log("you lvl up");
			player.playerLevel++;
			Debug.Log("player level is now " + player.playerLevel);
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
