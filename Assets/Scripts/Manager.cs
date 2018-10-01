using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

 public class Manager : Singleton<Manager> {
    public string myGlobalVar = "whatever";
    public float counter;
    public int activeMiniGame = 0;
    public int successCurrentGame = 0;
    public bool music = true;
    public bool sound = true;

	void Start() {
		counter = Time.timeSinceLevelLoad;
	}

	void Update(){
		counter = Time.timeSinceLevelLoad;
		if(successCurrentGame != 0) Debug.Log("Winner");
	}
 }