using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Text highScoreLabel;
    public Button button;
    public int nextSceneIndex;

	void Start() {
        Button btn1 = button.GetComponent<Button>();
        btn1.onClick.AddListener(() => TaskOnClick(btn1));
		if(SaveLoad.Load()){
			Game.current = SaveLoad.savedGame;
			highScoreLabel.text = Game.current.highScore.ToString();
		} else {
			Game.current = new Game();
		}
	}

    void TaskOnClick(Button btn1) {
        if(!Manager.Instance.start) {
            Manager.Instance.start = true;
            StartCoroutine(ChangeScene());
            //GameObject AudioManager = GameObject.Find("AudioManager");
			//DontDestroyOnLoad(GameObject.Find("Music"));
			//SceneManager.UnloadSceneAsync(0);
			//SceneManager.LoadScene(1);
			//SceneManager.MoveGameObjectToScene(AudioManager, SceneManager.GetSceneByName("MashingGame"));
			//DontDestroyOnLoad(AudioManager);
			//SceneManager.MoveGameObjectToScene(Music, SceneManager.GetSceneByName("MashingGame"));
		}
    }

    IEnumerator ChangeScene()
    {
		GameObject AudioManager = GameObject.Find("AudioManager");
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        Scene nextScene = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(AudioManager, nextScene);
        yield return null;
        SceneManager.UnloadScene(nextSceneIndex - 1);
    }
}
