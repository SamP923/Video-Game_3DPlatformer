using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float walkSpeed;
	public float jumpSpeed;

	Vector3 movement;

	Rigidbody playerRB;
	bool canJump;
	bool isGrounded = true; 

	public AudioSource coinSound;
	public AudioSource hurtSound;
	public AudioSource goalSound;

	// Use this for initialization
	void Start () {
		walkSpeed = 5f;
		playerRB = GetComponent<Rigidbody>();
		canJump = true;

	}
	
	// Update is called once per frame

	void FixedUpdate(){
		WalkHandler();
		JumpHandler();
	}

	void WalkHandler ()
	{
		//input on x horizonatl axis
		float hAxis = Input.GetAxis("Horizontal");
		//input on z vertical axis
		float vAxis = Input.GetAxis("Vertical");

		//movement in x
		float moveX = transform.position.x + hAxis * walkSpeed * Time.deltaTime;

		//movement in z
		float moveZ = transform.position.z + vAxis * walkSpeed * Time.deltaTime;

		//movement vector3 no jump
		movement = new Vector3(moveX, transform.position.y, moveZ);
		playerRB.MovePosition(movement);
	}

	void JumpHandler ()
	{
		float yAxis = Input.GetAxis ("Jump");

		float moveY = yAxis * jumpSpeed;

		Vector3 jumpVector = new Vector3 (0, moveY, 0);
		if (yAxis > 0) {
			if (canJump && isGrounded) {
				playerRB.AddForce (jumpVector, ForceMode.VelocityChange);
				canJump = false;
				Debug.Log("hi");
				isGrounded = false;
			} else {
				canJump = true;
			}
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		isGrounded = true;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Coin")) {
			coinSound.Play ();
			Destroy (other.gameObject);

			GameManager.instance.IncreaseScore(1);
		}

		if (other.CompareTag ("Enemy")) {
			hurtSound.Play ();
			GameManager.instance.DecreaseLives();
		}

		if (other.CompareTag ("Goal")) {
			goalSound.Play();
			Debug.Log("lol");
			GameManager.instance.IncreaseLevel();
		}
	}
}