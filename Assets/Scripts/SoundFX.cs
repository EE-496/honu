using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundFX : MonoBehaviour {

	public AudioClip soundClip;
    public AudioSource source;
    public Button button;

	void Start()
	{
		source.clip = soundClip;
        Button btn1 = button.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
	}

	//void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.Space))
	//		source.Play();
	//}

	void TaskOnClick ()
	{
        Manager.Instance.music = !Manager.Instance.music;
        if(Manager.Instance.music)
            source.Play();
		Debug.Log("You have clicked the Sound FX button!");
	}
}

