using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Text highScoreLabel;

	public void changeScene(string sceneName) {
		Game.current.highScore += 1;
        string nextScene = Manager.Instance.games[UnityEngine.Random.Range(0, Manager.Instance.games.Length)]; 
        GameObject MusicManager = GameObject.Find("MusicManager");
        GameObject Music = GameObject.Find("Music");
        GameObject ProgressBar = GameObject.Find("ProgressBar");
		DontDestroyOnLoad(ProgressBar);
		DontDestroyOnLoad(Music);
		DontDestroyOnLoad(MusicManager);
        SceneManager.LoadScene(nextScene);
        SceneManager.MoveGameObjectToScene(MusicManager, SceneManager.GetSceneByName(nextScene));
        SceneManager.MoveGameObjectToScene(Music, SceneManager.GetSceneByName(nextScene));
        SceneManager.MoveGameObjectToScene(ProgressBar, SceneManager.GetSceneByName(nextScene));
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
