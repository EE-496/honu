using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwatTheFly : MonoBehaviour {
	public GameObject fly;

	void Start() {
		GameObject fly1 = GameObject.Find("Fly1");
		// fly1.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0,Screen.height), Camera.main.nearClipPlane));
		// fly1.AddComponent<BoxCollider2D>();
		GameObject fly2 = GameObject.Find("Fly2");
		GameObject fly3 = GameObject.Find("Fly3");

	}

	void Update() {
		if(Manager.Instance.successCurrentGame == 3 && Manager.Instance.counter >= Constants.timeForGame){
			SceneManager.LoadScene("MainMenu");
		}
		 else if(Manager.Instance.counter >= Constants.timeForGame) {
			SceneManager.LoadScene("GameOver");
		}
	}	
}
