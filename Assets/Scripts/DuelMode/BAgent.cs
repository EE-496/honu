using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class BAgent : Agent {

	Rigidbody2D rBody;
	public GameObject PlayerGoalA;
	public GameObject PlayerGoalB;
	Rigidbody2D goalA;
	Rigidbody2D goalB;

	void Start () {
		rBody = GetComponent<Rigidbody2D>();
		goalA = PlayerGoalA.GetComponent<Rigidbody2D>();
		goalB = PlayerGoalB.GetComponent<Rigidbody2D>();
	}

	public Transform Ball;
	public override void AgentReset()
	{
		this.transform.position = new Vector2(7.0f,0.0f);
		//this.rBody.velocity = Vector2.zero;
	}

	public override void CollectObservations()
	{
	    // Calculate relative position
	    Vector2 relativePosition = Ball.position - this.transform.position;

	    // Relative position
	    AddVectorObs(relativePosition.x/5);
	    AddVectorObs(relativePosition.y/5);

	    // Agent velocity
	    AddVectorObs(rBody.velocity.x/5);
	    AddVectorObs(rBody.velocity.y/5);
	}

	public float speed = 15;
	private float previousDistance = float.MaxValue;

	/*void OnTriggerEnter2D(Collider2D col) {
		if(col == Ball) {
			AddReward(1.0f);
		}
	 }*/

	public override void AgentAction(float[] vectorAction, string textAction)
	{
	    // Rewards
	    float distanceToBall = Vector2.Distance(this.transform.position, Ball.position);
		float scoreDistance = Vector2.Distance(goalA.position, Ball.position);
		float defendDistance = Vector2.Distance(goalB.position, Ball.position);
		// Time penalty
		// AddReward(scoreDistance*.01f);
		// AddReward(defendDistance*-.01f);
		if (GetComponent<Collider2D>().IsTouching(Ball.GetComponent<Collider2D>())) {
			AddReward(150.0f);
		} else{
			AddReward(-0.2f);
		}

		if(scoreDistance < 0.1f){
			AddReward(300.0f);
			Done();
		} else if(defendDistance < 0.1f){
			AddReward(-10.0f);
			Done();
		}
	    // Actions, size = 2
	    Vector2 controlSignal = Vector2.zero;
	    controlSignal.x = vectorAction[0];
	    controlSignal.y = vectorAction[1];
	    // rBody.AddForce(controlSignal * speed);
		rBody.velocity = new Vector2(controlSignal.x*speed, controlSignal.y *speed);
	 }
}
