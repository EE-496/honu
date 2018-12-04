using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

static class Constants {
    public const int miniGameCount = 2;
    public const float timeForGame = 5.0f;
}

public class Manager : Singleton<Manager> {
    public float counter;
    public int activeMiniGame = 0;
    public int successCurrentGame = 0;
    public bool music = true;
    public bool sound = true;
	public bool lose = false;
	public bool start = false;

	void Start() {
		counter = Time.timeSinceLevelLoad;
	}

	void Update(){
		counter = Time.timeSinceLevelLoad;
		if(successCurrentGame != 0) {
            Debug.Log("Winner");
        }
        if(lose) {
            SceneManager.LoadScene("GameOver");
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            lose = false;
            start = false;
        }
	}
 }