using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwatTheFly : MonoBehaviour {
	public GameObject fly;

	void Update() {
		if(Manager.Instance.successCurrentGame == 3) {
			GameObject checkMark = new GameObject();
			if(Manager.Instance.counter >= Constants.timeForGame) {
				SceneManager.LoadScene("MainMenu");
			}
		}
		else if(Manager.Instance.counter >= Constants.timeForGame) {
			SceneManager.LoadScene("GameOver");
		}
	}	
}
