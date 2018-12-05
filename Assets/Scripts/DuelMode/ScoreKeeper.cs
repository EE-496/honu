using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {
	public GameObject ball;
	public GameObject PlayerGoalA;
	public GameObject PlayerGoalB;   
	public Text PlayerScoreA;
    public Text PlayerScoreB;
	private Collider2D goalA;
	private Collider2D goalB;
	private int scoreA = 0; // Player A's Score
	private int scoreB = 0; // Player B's Score
	private int goalsToWin = 1;

	private bool showText = false, goalScored = false;
	private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 2.0f;

	// Use this for initialization
	void Start () {
		goalA = PlayerGoalA.GetComponent<Collider2D>();
		goalB = PlayerGoalB.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentTime = Time.time;
		if(goalScored)
			showText = true;
		else
			showText = false;
		
		if(executedTime != 0.0f) {
			if(currentTime - executedTime > timeToWait)
			{
				executedTime = 0.0f;
				goalScored = false;
				this.transform.position = Vector2.zero;
				this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}
		if(scoreA == goalsToWin) {
			SceneManager.LoadScene("Winner");
		} else if (scoreB == goalsToWin) {
			SceneManager.LoadScene("GameOver");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		executedTime = Time.time;
        if(col == goalA) {
			scoreB += 1;
			PlayerScoreB.text = scoreB.ToString();
			goalScored = true;
		} else if (col == goalB) {
			scoreA += 1;
			PlayerScoreA.text = scoreA.ToString();
			goalScored = true;
		}
    }
     
	void OnGUI(){
		GUIStyle myStyle = new GUIStyle();
		myStyle.alignment = TextAnchor.MiddleCenter;
     	myStyle.fontSize = 32;
		if(showText) GUI.Label(new Rect(Screen.width / 2.65f, Screen.height / 4.5f, 200, 50), "Goal!", myStyle);
	}
}
