using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

static class Constants {
    public const int miniGameCount = 6;
    public const float timeForGame = 5.0f;
}

public class Manager : Singleton<Manager> {
    public float counter;
    public int activeMiniGame = 0;
    public int successCurrentGame = 0;
    public bool music = true;
    public bool sound = true;
    public readonly string[] games = {"DragGame", "Drawing",
     "SequenceGame", "SpinningGame", "SwatTheFly", "Timing"};

	void Start() {
		counter = Time.timeSinceLevelLoad;
	}

	void Update(){
		counter = Time.timeSinceLevelLoad;
		Scene scene = SceneManager.GetActiveScene();
		if(successCurrentGame != 0 && counter >= Constants.timeForGame) {
		    Game.current.highScore += 1;
            successCurrentGame = 0;
            Debug.Log("Winner");
		    SceneManager.LoadScene(games[UnityEngine.Random.Range(0, games.Length)]);
        } else if(counter >= Constants.timeForGame && scene.name != "MainMenu") {
            successCurrentGame = 0;
			SceneManager.LoadScene("GameOver");
		}
	}
 }