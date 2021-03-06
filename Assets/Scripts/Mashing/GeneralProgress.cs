﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralProgress : MonoBehaviour{
	public float progress; // value between 0 and approximately 1
	public Vector2 position = new Vector2(20, 50); // position of the progress bar
	public Vector2 size = new Vector2(10, 10); // total length/width of progress bar
	public Texture2D progress_empty_Image; // texture for background of progress bar
	public Texture2D progress_full_Image; // texture for fill of progress bar

	public float goal;
	public PlayerController actual;

	// initialize the progress based on the percentage of time passed over total time
	void Start() {
		progress = actual.total / goal;
	}

	// Update is called once per frame
	void Update() {
		if (progress < 1) {
			progress =  actual.total / goal;
		}
	}

	void OnGUI() {
		// draw the background
		GUI.DrawTexture(new Rect(position.x, position.y, size.x, size.y), progress_empty_Image);
		// fill with appropriate progress
        GUI.DrawTexture(new Rect(position.x, position.y, size.x * (1-progress), size.y), progress_full_Image);
	}

}
