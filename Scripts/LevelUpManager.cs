using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player != null) {
            // Debug.Log(this + " should have found Player");
        }

		Debug.Log(this + " says player xp is " + PlayerController.playerXP);
		CheckLvlUp(PlayerController.playerXP);
	}

	void CheckLvlUp(int currentXP) {
		Debug.Log("player level is " + PlayerController.playerLevel);
		Debug.Log("calculating if there is a lvl up");
		if (currentXP >= 83 && PlayerController.playerLevel < 2) {
			Debug.Log("you lvl up");
			PlayerController.playerLevel++;
			Debug.Log("player level is now " + PlayerController.playerLevel);
			AbilityLevelUp(2);
		}
		if (currentXP >= 174 && PlayerController.playerLevel < 3) {
			Debug.Log("you lvl up");
			PlayerController.playerLevel++;
			Debug.Log("player level is now " + PlayerController.playerLevel);
			AbilityLevelUp(2);
		}
		if (currentXP >= 276 && PlayerController.playerLevel < 4) {
			Debug.Log("you lvl up");
			PlayerController.playerLevel++;
			Debug.Log("player level is now " + PlayerController.playerLevel);
			AbilityLevelUp(2);
		}
		if (currentXP >= 388 && PlayerController.playerLevel < 5) {
			Debug.Log("you lvl up");
			PlayerController.playerLevel++;
			Debug.Log("player level is now " + PlayerController.playerLevel);
			AbilityLevelUp(5);
		}
		else {
			Debug.Log("no lvl up");
		}
	}

	void AbilityLevelUp(int modifier) {
		if (PlayerController.playerLevel == 2) {
			Debug.Log("player constitution is " + PlayerController.playerCon);
			PlayerController.playerCon += modifier;
			Debug.Log("player constitution is now " + PlayerController.playerCon);

			Debug.Log("player strength is " + PlayerController.playerStr);
			PlayerController.playerStr += modifier;
			Debug.Log("player strength is now " + PlayerController.playerStr);
		}
		if (PlayerController.playerLevel == 3) {
			Debug.Log("player constitution is " + PlayerController.playerCon);
			PlayerController.playerCon += modifier;
			Debug.Log("player constitution is now " + PlayerController.playerCon);

			Debug.Log("player strength is " + PlayerController.playerStr);
			PlayerController.playerStr += modifier;
			Debug.Log("player strength is now " + PlayerController.playerStr);
		}
		if (PlayerController.playerLevel == 4) {
			Debug.Log("player constitution is " + PlayerController.playerCon);
			PlayerController.playerCon += modifier;
			Debug.Log("player constitution is now " + PlayerController.playerCon);

			Debug.Log("player strength is " + PlayerController.playerStr);
			PlayerController.playerStr += modifier;
			Debug.Log("player strength is now " + PlayerController.playerStr);
		}
		if (PlayerController.playerLevel == 5) {
			Debug.Log("player constitution is " + PlayerController.playerCon);
			PlayerController.playerCon += modifier;
			Debug.Log("player constitution is now " + PlayerController.playerCon);

			Debug.Log("player strength is " + PlayerController.playerStr);
			PlayerController.playerStr += modifier;
			Debug.Log("player strength is now " + PlayerController.playerStr);
		}
	}
}
