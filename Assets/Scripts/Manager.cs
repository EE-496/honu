using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

 public class Manager : Singleton<Manager> {
    public string myGlobalVar = "whatever";
	public float counter = Time.timeSinceLevelLoad;
    public bool music = false;

	void Update(){
		counter = Time.timeSinceLevelLoad;
	}
 }