using UnityEngine;
using System.Collections;

public class playerLScript : MonoBehaviour {

	[HideInInspector]
	public bool facingLeft = true;			// For determining which way the player is currently facing.
	public float speed = 10.0F;
	public float rotationSpeed = 5.0F;
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 500f;
	//check grounded
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 1.0f;
	public LayerMask ground;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, ground);
		float h = Input.GetAxis ("p1Horizontal");
		float y = Input.GetAxis ("p1Vertical") * speed;
		if (h > 0 && !facingLeft) {
			Flip();
		}if (h < 0 && facingLeft) {
			Flip();
		}
		
		if (y > 0 && grounded) {
			//rigidbody2D.AddForce(new Vector2(0,200f));
			rigidbody2D.Sleep();
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			//y =0;
		}
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
		//rigidbody2D.AddForce (new Vector2 (x, 0));
		//rigidbody2D.velocity = new Vector2 (x, y);      // ( new Vector2(x, 0));
	}
//	void OnCollisionEnter2D (Collision2D  col) 
//	{
//		print (col.gameObject.name);
//			if (col.gameObject.name == "rocket") {
//					print ("vao day roi");
//			}
//	}
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
