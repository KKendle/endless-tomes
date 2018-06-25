using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player != null) {
            Debug.Log("level up manager should have found Player");
        }
	}
}
