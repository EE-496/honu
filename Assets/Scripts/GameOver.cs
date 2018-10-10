using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Manager.Instance.counter);
		if(Manager.Instance.counter >= Constants.timeForGame){
            SceneManager.LoadScene("MainMenu");
            Debug.Log("You Lose!");
        }
	}
}
