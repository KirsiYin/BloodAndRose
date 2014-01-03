using UnityEngine;
using System.Collections;

public class gun1 : MonoBehaviour {

	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;
	private playerLScript playerCtr;
	float nextfire;
	float firerate = 0.5f;
	// Use this for initialization
	void Awake()
	{
		// Setting up the references
		playerCtr = transform.root.GetComponent<playerLScript>();
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//		DateTime curr = DateTime.Now;
		//		System.TimeSpan dt = curr.Subtract(lastTime);
		//		if (dt.Milliseconds < 400)
		//						return;
		//lastTime = curr;

		if(Input.GetButton("Fire1") && Time.time > nextfire)
		{
//			print("asd" + playerCtr.facingLeft);
			nextfire = Time.time + firerate;
			if(playerCtr.facingLeft)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position,Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.tag = "playerR";
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.tag = "playerR";
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
