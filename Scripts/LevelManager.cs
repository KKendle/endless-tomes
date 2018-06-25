using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

//	static LevelManager instance = null;

//	private MusicPlayer musicPlayer;

	public float autoLoadNextLevelAfter;

	// temp function to see that level changing works
	void Start() {
		// splash screen
		if(SceneManager.GetActiveScene().name == "splash") {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
		Scene scene = SceneManager.GetActiveScene();
		Debug.Log("Active scene is " + scene.name);
//		if (instance != null && instance != this) {
//			Destroy(gameObject);
//			Debug.Log("Duplicate music player found. Destroying");
//		}
//		else {
//			instance = this;
//			GameObject.DontDestroyOnLoad(gameObject);
//		}

		if(SceneManager.GetActiveScene().name == "Lose") {
			Debug.Log("lose screen");
//			ResetGameStats();
		}

//		musicPlayer = GameObject.Find("Music Player").GetComponent<MusicPlayer>();
//		if(musicPlayer == null) {
//			Debug.Log("Music Player not found");
//		}
//		musicPlayer.ChangeMusic();
	}		

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
//		musicPlayer.ChangeMusic(name);
		SceneManager.LoadScene(name);
//		musicPlayer.ChangeMusic(name);
	}

	public void QuitRequest() {
		Debug.Log("I want to quit");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadPreviousLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

//	void ResetGameStats() {
//		Debug.Log("Resetting stats");
//		ScoreKeeper.Reset();
//		PlayerHealth.Reset();
//		PlayerShield.Reset();
//		EnemyDrops.itemDropCount = 0;
//		EnemyBehavior.scoreEnemy = 0;
//		Coin.scoreCoin = 0;
//	}
}
