using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalLine : MonoBehaviour {
	public GameObject ball;
    private Collider2D bc2d;

	// Use this for initialization
	void Start () {
		bc2d = GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), bc2d);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
}
