using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sequence : MonoBehaviour {
	public int sequenceLength;
	public Text gameString;

	private int progressInSequence = 0;
	private List<char> sequence = new List<char>();
	private char[] charList = { 'w', 'a', 's', 'd' };

	// Use this for initialization
	void Start () {
		generateSequence(charList, sequenceLength);
		for(int i = 0; i < sequenceLength; i++){
			gameString.text = gameString.text + sequence[i].ToString().ToUpper() + " ";
		}
	}
	
	// Update is called once per frame
	void Update () {
		readInput();
		if(checkSequence()){
            Manager.Instance.successCurrentGame = 1;
			Game.current.highScore += 1;
			Debug.Log("Win!");
        } else if(Manager.Instance.counter >= Constants.timeForGame && Manager.Instance.successCurrentGame != 1){
            SceneManager.LoadScene("GameOver");
        }
	}

	void generateSequence(char[] keys, int length) {
		for(int i = 0; i < length; i++){
			sequence.Add(charList[Random.Range(0, 4)]);
		}
	}

	void readInput() {
		if (Input.GetKeyDown(KeyCode.W) && sequence[progressInSequence] == 'w') {
			progressInSequence++;
        } else if (Input.GetKeyDown(KeyCode.A) && sequence[progressInSequence] == 'a') {
			progressInSequence++;
        } else if (Input.GetKeyDown(KeyCode.S) && sequence[progressInSequence] == 's') {
			progressInSequence++;
        } else if (Input.GetKeyDown(KeyCode.D) && sequence[progressInSequence] == 'd') {
			progressInSequence++;
        }
	}

	bool checkSequence() {
		if(progressInSequence == sequenceLength-1) return true;
		return false;
	}
}
