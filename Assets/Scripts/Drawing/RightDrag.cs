using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDrag : MonoBehaviour {

    public bool success = false;
    bool followingModeOn = false;
    bool move = true;

    void OnMouseDown()
    {
        if (move)
            followingModeOn = true;
    }

    void OnMouseUp()
    {
        if (move)
            followingModeOn = false;
    }

    void Update()
    {
        if (followingModeOn)
        {
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = new Vector2(x, -x);
        }
        if (transform.position.y < -4.0) {
            move = false;
            followingModeOn = false;
            success = true;
        }
    }

}
