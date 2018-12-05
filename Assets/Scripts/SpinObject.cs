using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinObject : MonoBehaviour {
    
	public float glPlFltDeltaLimit; //60
	public float glPlFltDeltaReduce; //2
	public int rotationsToWin; //25
	public bool rotate { get; set; }
	public AudioClip musicClip;
	public AudioSource musicSource;
	public Text interfaceText;

    private int currentRotations;
    private float glPrFltDeltaRotation;
    private float glPrFltPreviousRotation;
    private float glPrFltCurrentRotation;
	private float glPrFloatRotation;
	private float glPrFltQuarterRotation;


	void Start()
	{
		currentRotations =  rotationsToWin;
		glPrFloatRotation = 0f;
		rotate = true;

		musicSource.clip = musicClip;
		interfaceText.text = rotationsToWin.ToString();
		if (Manager.Instance.music)
			musicSource.Play();
		Manager.Instance.successCurrentGame = 0;
	}

	// Update is called once per frame
	void Update()
	{
        RotateThis();
        if (rotate) {
            CountRotations();
        }
	}

	private void CountRotations()
	{
		if (Mathf.Sign(glPrFltDeltaRotation) == 1)
		{
			glPrFloatRotation += glPrFltDeltaRotation;
		}

		if (glPrFloatRotation >= 360)
		{
			glPrFloatRotation -= 360;
            currentRotations -= 1;
			interfaceText.text = currentRotations.ToString();
            if (currentRotations <= 0)
			{
				Manager.Instance.successCurrentGame = 1;
                rotate = false;
			}
		}
	}

	private void RotateThis()
	{
		if (Input.GetMouseButtonDown(0) && rotate)
		{

			// Get initial rotation of this game object
			glPrFltDeltaRotation = 0f;
			glPrFltPreviousRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		else if (Input.GetMouseButton(0) && rotate)
		{

			// Rotate along the mouse under Delta Rotation Limit
			glPrFltCurrentRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			glPrFltDeltaRotation = Mathf.DeltaAngle(glPrFltCurrentRotation, glPrFltPreviousRotation);
			if (Mathf.Abs(glPrFltDeltaRotation) > glPlFltDeltaLimit)
			{
				glPrFltDeltaRotation = glPlFltDeltaLimit * Mathf.Sign(glPrFltDeltaRotation);
			}
			glPrFltPreviousRotation = glPrFltCurrentRotation;
			transform.Rotate(Vector3.back * Time.deltaTime, glPrFltDeltaRotation);
		}
		else
		{

			// Inertia
			transform.Rotate(Vector3.back * Time.deltaTime, glPrFltDeltaRotation);
			glPrFltDeltaRotation = Mathf.Lerp(glPrFltDeltaRotation, 0, glPlFltDeltaReduce * Time.deltaTime);
		}
	}

	private float angleBetweenPoints(Vector2 v2Position1, Vector2 v2Position2)
	{
		Vector2 v2FromLine = v2Position2 - v2Position1;
		Vector2 v2ToLine = new Vector2(1, 0);

		float fltAngle = Vector2.Angle(v2FromLine, v2ToLine);

		// If rotation is more than 180
		Vector3 v3Cross = Vector3.Cross(v2FromLine, v2ToLine);
		if (v3Cross.z > 0)
		{
			fltAngle = 360f - fltAngle;
		}

		return fltAngle;
	}

}
