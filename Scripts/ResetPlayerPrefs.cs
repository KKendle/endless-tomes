using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour {

	private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);

			// reset player prefs
			// only for dev
			PlayerPrefs.DeleteKey("Ally1 experience");
			PlayerPrefs.DeleteKey("Player experience");
        }
    }
}
