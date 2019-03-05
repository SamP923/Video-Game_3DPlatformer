using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {

	/*int num;
	float decnum = 3.4f;
	string word = "word";
	bool check = true;

	float celsius;
	float farenheit;
	*/

	public float scaleFactor = 1.2f;
	public float maxScale = 3;

	// Use this for initialization
	void Start ()
	{
		//farenheit = celsius * 9/5 + 32;
		if (scaleFactor < 1) {
			Debug.Log ("the balloon is too small");
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown ()
	{
		float xScale = transform.localScale.x;
		float yScale = transform.localScale.y;
		float zScale = transform.localScale.z;

		transform.localScale = new Vector3 (xScale * scaleFactor, yScale * scaleFactor, zScale * scaleFactor);
		if ( xScale > maxScale) {
			Destroy (gameObject);
		}
	}
}
