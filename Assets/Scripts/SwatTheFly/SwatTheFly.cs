using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwatTheFly : MonoBehaviour {
	public MoveObject fly1;
	public MoveObject fly2;
	public MoveObject fly3;

	void Update() {
		if(fly1.clicks == 1 && fly2.clicks == 1  && fly3.clicks == 1) {
    		Manager.Instance.successCurrentGame = 1;
		}
	}	
}
