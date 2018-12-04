using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip musicClip;
	public AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicSource.clip = musicClip;
        if (Manager.Instance.music) musicSource.Play();
	}
}
