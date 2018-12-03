using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Text highScoreLabel;

	public void changeScene(string sceneName) {
		Game.current.highScore += 1;
		SceneManager.LoadScene(Manager.Instance.games[UnityEngine.Random.Range(0, Manager.Instance.games.Length)]);
	}

	void Start() {
		if(SaveLoad.Load()){
			Game.current = SaveLoad.savedGame;
		} else if (Game.current == null) {
			Game.current = new Game();
			Game.current.highScore = 0;
		}
		highScoreLabel.text = Game.current.highScore.ToString();
		Game.current.highScore = 0;
	}

}
