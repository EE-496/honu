using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float delta = 150f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    Vector2 startPos;
    private bool slide = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (slide)
        {
            Vector2 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if(Input.anyKey){
            slide = false;
        }
        if(!slide){
            if (transform.position.x < 1.46 && transform.position.x > -2.75) {
                //move to win screen
            }
            else{
                //move to lose screen
            }
        }
    }
}

