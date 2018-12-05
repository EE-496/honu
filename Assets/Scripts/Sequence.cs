using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sequence : MonoBehaviour {
	public int sequenceLength;
	public Text gameString;
	public GameObject checkmark;
	public Transform canvasTransfrom;

	private int progressInSequence = 0;
	private List<char> sequence = new List<char>();
	private char[] charList = { 'w', 'a', 's', 'd' };

	// Use this for initialization
	void Start () {
		generateSequence(charList, sequenceLength);
		for(int i = 0; i < sequenceLength; i++){
			gameString.text = gameString.text + sequence[i].ToString().ToUpper() + " ";
		}
		Manager.Instance.successCurrentGame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		readInput();
		if(checkSequence()){
            Manager.Instance.successCurrentGame = 1;
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
			GameObject newObject = GameObject.Instantiate(checkmark, canvasTransfrom);
			RectTransform rt = newObject.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector3(-240 + (60*progressInSequence), -150, 0);
        } else if (Input.GetKeyDown(KeyCode.A) && sequence[progressInSequence] == 'a') {
			progressInSequence++;
			GameObject newObject = GameObject.Instantiate(checkmark, canvasTransfrom);
			RectTransform rt = newObject.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector3(-240 + (60*progressInSequence), -150, 0);
        } else if (Input.GetKeyDown(KeyCode.S) && sequence[progressInSequence] == 's') {
			progressInSequence++;
			GameObject newObject = GameObject.Instantiate(checkmark, canvasTransfrom);
			RectTransform rt = newObject.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector3(-240 + (60*progressInSequence), -150, 0);
        } else if (Input.GetKeyDown(KeyCode.D) && sequence[progressInSequence] == 'd') {
			progressInSequence++;
			GameObject newObject = GameObject.Instantiate(checkmark, canvasTransfrom);
			RectTransform rt = newObject.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector3(-240 + (60*progressInSequence), -150, 0);
        }
	}

	bool checkSequence() {
		if(progressInSequence == sequenceLength) return true;
		return false;
	}
}
