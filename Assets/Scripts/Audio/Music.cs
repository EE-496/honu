using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

	public AudioClip soundClip;
    public AudioSource source;
    public Button button;

    void Start()
    {
        source.clip = soundClip;
		Button btn1 = button.GetComponent<Button>();
		btn1.GetComponentInChildren<Text>().text = "Turn Music off";
		btn1.onClick.AddListener(() => TaskOnClick(btn1));
	}

	void TaskOnClick (Button btn1)
	{
        Manager.Instance.music = !Manager.Instance.music;

        if(Manager.Instance.music) {
            Debug.Log("Music turned on!");
            btn1.GetComponentInChildren<Text>().text = "Turn Music off";
            source.Play();
        }
        else {
			Debug.Log("Music turned off!");
            btn1.GetComponentInChildren<Text>().text = "Turn Music on";
            source.Pause();
		}
	}
}

