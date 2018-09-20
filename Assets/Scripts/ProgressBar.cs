using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBar : MonoBehaviour {

    public int time = 10;
	public float progress;
    public float speed = 0;
    bool check = false;
    public Vector2 position = new Vector2(20, 40);
    public Vector2 size = new Vector2(200, 20);
    public Texture2D progress_empty_Image;
    public Texture2D progress_full_Image;
	
    void Start() {
        if(Manager.Instance.counter != null){
            progress = Manager.Instance.counter / 10;
        }
    }

    // Update is called once per frame
	void Update () {
        if (check == false) {
            StartCoroutine(delay());
        }
	}

    void OnGUI () {
        // draw the background:
		GUI.BeginGroup(new Rect(position.x, position.y, size.x, size.y));
		    GUI.Box(new Rect(0, 0, size.x, size.y), progress_empty_Image);

		    // draw the filled-in part:
		    GUI.BeginGroup(new Rect(0, 0, size.x * progress, size.y));
                GUI.Box(new Rect(0, 0, size.x, size.y), progress_full_Image);
		    GUI.EndGroup();

		GUI.EndGroup();
    }

    IEnumerator delay() {
        check = true;
        if (progress < 1) {
            progress = Manager.Instance.counter / 10;
        }
        yield return new WaitForSeconds(speed);
        check = false;
    }
}
