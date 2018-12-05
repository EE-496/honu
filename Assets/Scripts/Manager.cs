using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

static class Constants {
    public const int miniGameCount = 6;
    public const float timeForGame = 4.5f;
}

public class Manager : Singleton<Manager> {
    public float counter;
    public int activeMiniGame = 0;
    public int successCurrentGame = 0;
    public bool music = true;
    public bool sound = true;
    public float timeForGame = 4.5f;
    public readonly string[] games = {"DragGame", "Drawing", "Mashing",
     "SequenceGame", "SpinningGame", "SwatTheFly", "Timing"};

	void Start() {
		counter = 0;
        successCurrentGame = 0;
	}

	void Update(){
		counter = Time.timeSinceLevelLoad;
		Scene scene = SceneManager.GetActiveScene();
		if(successCurrentGame == 1 && counter >= timeForGame) {
		    Game.current.highScore += 1;
            counter = 0;
            timeForGame -= 0.1f;
            successCurrentGame = 0;
		    SceneManager.LoadScene(games[UnityEngine.Random.Range(0, games.Length)]);
        } else if((successCurrentGame == 0 && counter >= Constants.timeForGame) && scene.name != "MainMenu" && scene.name != "DuelMode" && scene.name != "GameOver" && scene.name != "Winner") {
			SceneManager.LoadScene("GameOver");
		} else if((scene.name == "GameOver" || scene.name == "Winner") && counter >= Constants.timeForGame){
            counter = 0;
            timeForGame = 4.5f;
            SceneManager.LoadScene("MainMenu");
        } else if(scene.name == "MainMenu" || scene.name == "Duel Mode") {
            counter = 0;
        }
	}
 }