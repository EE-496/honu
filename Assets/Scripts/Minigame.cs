using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour {
	// Use this for initialization
	void Start () {
		switch(Manager.Instance.activeMiniGame){
			case 0:
				Debug.Log("Hello0");
				break;
			case 1:
				Debug.Log("Hello1");
				break;
			default:
				Debug.Log("Default");
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
