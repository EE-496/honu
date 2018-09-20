using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public void changeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
		Manager.Instance.activeMiniGame = 1;
	}

	void Start() {
		if(SaveLoad.Load()){
			Game.current = SaveLoad.savedGame;
			Debug.Log("Highscore: " + Game.current.highScore);
		} else {
			Game.current = new Game();
		}
	}

}
