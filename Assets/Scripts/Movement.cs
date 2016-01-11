using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 15f;
	Vector3 movement;
	Vector2 maxVelocity = new Vector2 (5, 3);
	Rigidbody2D playerRigidbody;
	private bool jump;
	private bool grounded = false;
	private bool groundedLeft = false;
	private bool groundedRight = false;
	public Transform LinecastToGroundLeft;
	public Transform LinecastToGroundRight;
	private PlayerController playerController;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody2D> ();

	}

	void Start()
	{
		playerController = GetComponent<PlayerController>() as PlayerController;
		//playerRigidbody.gravityScale = 0;
	}

	/*void Update()
	{
		groundedLeft = Physics2D.Linecast(this.transform.position, LinecastToGroundLeft.position, 1 << LayerMask.NameToLayer("Environment"));
		groundedRight = Physics2D.Linecast(this.transform.position, LinecastToGroundRight.position, 1 << LayerMask.NameToLayer("Environment"));
		Debug.Log (groundedLeft);
		if (groundedLeft == true || groundedRight == true) {
			grounded = true;
		} else if(!groundedLeft && !groundedRight){
			grounded = false;
		}
	}*/

	/*
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, LinecastToGroundLeft.transform.position);
		Gizmos.DrawLine(transform.position, LinecastToGroundRight.transform.position);
	}*/

	void Update()
	{
		UIManager.Instance.UpdateScore (-transform.position.y);
	}

	void FixedUpdate()
	{
		var forceX = 0.0f;
		var forceY = 0.0f;
		Vector2 tempVelocity = playerRigidbody.velocity;
		Debug.Log (playerRigidbody.velocity.y);
		if (playerController.moving.x != 0 && playerRigidbody.velocity.y == 0) {
			if (Mathf.Abs (playerRigidbody.velocity.x) < maxVelocity.x) {
				forceX = playerController.moving.x * speed;
			} 

			if (playerController.moving.y != 0 && grounded) {
				Debug.Log("Grpunded " + grounded);
				forceY = 300f;
			}
		}

		tempVelocity.x = forceX;
		playerRigidbody.velocity = tempVelocity;

		//movement.Set (playerController.moving.x, 0, 0);
		//movement = movement * speed * Time.deltaTime;
		//playerRigidbody.MovePosition (transform.position + movement);
		CheckBounds ();
		//playerRigidbody.AddForce (new Vector2 (forceX, forceY));
	}
	
	void CheckBounds()
	{
		float x = transform.position.x;
		float z = transform.position.z;
		x = Mathf.Clamp (x, -4, 4);
		transform.position = new Vector2 (x, transform.position.y);
	}

}
