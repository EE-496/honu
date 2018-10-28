using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
	public GameObject moveObject;

	private Rigidbody2D rb2D;
	private bool clicked = false;

	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		// Vector2 force = new Vector2(Random.Range(-25.0f,25.0f),Random.Range(-25.0f,25.0f));
        // rb2D.AddForce(force);
		// Vector3 center3 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane)); 
		// Vector2 center2 = new Vector2(center3.x, center3.y);
		// Vector2 gameObjectPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		// Vector2 direction = new Vector2(center2.x - gameObjectPos.x, center2.y - gameObjectPos.y);
		// rb2D.AddForce(direction);

		// Keep inside the frame
		Vector3 pos = Camera.main.WorldToViewportPoint (gameObject.transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

	void OnMouseDown() {
		if(!clicked) {
			Debug.Log("HERE");
    		Manager.Instance.successCurrentGame += 1;
			clicked = true;
		}
	}
}
