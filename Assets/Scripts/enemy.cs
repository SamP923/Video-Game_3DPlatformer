using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed = 10f;
	public float rangeY = 1.5f;
	public int direction = 1;
	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float movementY = speed * Time.deltaTime * direction;
		float newY = transform.position.y + movementY;

		if (Mathf.Abs (newY - initialPosition.y) > rangeY) {
			direction *= -1;
		} else {
			transform.position += new Vector3(0, movementY, 0);
		}
	}
}
