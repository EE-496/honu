using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float delta = 150f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    Vector2 startPos;
    private bool slide = true;
    // Use this for initialization

    void Start() {
        startPos = transform.position;
        Manager.Instance.successCurrentGame = 0;
    }

    void Update() {
        if (slide) {
            Vector2 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if (Input.anyKey) {
            slide = false;
        }
        if (!slide){
            if (transform.position.x < 1.52 && transform.position.x > -2.98){
                Manager.Instance.successCurrentGame = 1;
            }
        }
    }
}
