using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundFX : MonoBehaviour
{

	public AudioClip soundClip;
	public AudioSource source;
	public Button button;

	void Start()
	{
		source.clip = soundClip;
		Button btn1 = button.GetComponent<Button>();
		btn1.GetComponentInChildren<Text>().text = "Turn Sound FX off";
		btn1.onClick.AddListener(() => TaskOnClick(btn1));
	}

	void TaskOnClick (Button btn1)
	{
		if (!Manager.Instance.sound)
			source.Play();

		Manager.Instance.sound = !Manager.Instance.sound;
		if (Manager.Instance.sound)
		{
			Debug.Log("Sound FX turned on!");
			btn1.GetComponentInChildren<Text>().text = "Turn Sound FX off";
		}
		else
		{
			Debug.Log("Sound FX turned off!");
			btn1.GetComponentInChildren<Text>().text = "Turn Sound FX on";
		}
	}
}

