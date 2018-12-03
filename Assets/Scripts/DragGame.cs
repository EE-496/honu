using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGame : MonoBehaviour {

    //public GameObject rice;
    //public GameObject poke;
    public GameObject bowl;
    public bool draggingMode = false;
    public int objectsInBowl = 0;
	private float time = 10;
    private bool win = false;

    void Update()
    {
		if (!win && Manager.Instance.counter < time)
		{
            MoveObjects();
        } else if (win || objectsInBowl == 3) {
            Debug.Log("You Win!");
    		Manager.Instance.successCurrentGame += 1;
            enabled = false;
        } else {
			Debug.Log("You Lose");
            enabled = false;
		}
    }

	void MoveObjects()
	{
		if (Input.GetMouseButtonDown(0))
		{
			draggingMode = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			draggingMode = false;
            if (objectsInBowl == 3) {
                win = true;
            }
		}

		if (draggingMode)
		{
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			touchPosition.z = 0.0f;
			Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);

			RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.name != "Bowl")
			{
				//Debug.Log(hit.collider.gameObject.name);
				hit.collider.gameObject.transform.position = touchPosition;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Bowl collided with " + col.name);
        objectsInBowl += 1;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("Bowl collided with " + col.name);
		objectsInBowl -= 1;
	}
}
