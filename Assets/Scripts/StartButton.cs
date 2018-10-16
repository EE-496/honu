using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Text highScoreLabel;

	public void changeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	void Start() {
		if(SaveLoad.Load()){
			Game.current = SaveLoad.savedGame;
			highScoreLabel.text = Game.current.highScore.ToString();
		} else {
			Game.current = new Game();
			highScoreLabel.text = "0";
		}
	}

}
