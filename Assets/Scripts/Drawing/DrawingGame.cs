using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingGame : MonoBehaviour {

	public Drag LineA;
	public RightDrag LineB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(LineA.success == true && LineB.success == true) Manager.Instance.successCurrentGame = 1;
	}
}
