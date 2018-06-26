using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player != null) {
            Debug.Log(this + " should have found Player");
        }

		Debug.Log("LevelUpManager says player xp is " + PlayerController.playerXP);
		CheckLvlUp(PlayerController.playerXP);
	}

	void CheckLvlUp(int currentXP) {
		Debug.Log("player level is " + PlayerController.playerLevel);
		Debug.Log("calculating if there is a lvl up");
		if (currentXP >= 10 && PlayerController.playerLevel < 2) {
			Debug.Log("you lvl up");
			PlayerController.playerLevel++;
			Debug.Log("player level is now " + PlayerController.playerLevel);
		}
		else {
			Debug.Log("no lvl up");
		}
	}
}
