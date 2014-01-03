using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class gun : MonoBehaviour {
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;
	private playerRScript playerCtr;
	private DateTime lastTime;
	float nextfire;
	float firerate = 0.5f;
	// Use this for initialization
	void Awake()
	{
		// Setting up the references
		playerCtr = transform.root.GetComponent<playerRScript>();
	}
	void Start () {
		lastTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		//return;
//		DateTime curr = DateTime.Now;
//		System.TimeSpan dt = curr.Subtract(lastTime);
//		if (dt.Milliseconds < 400)
//						return;
		//lastTime = curr;
		if(Input.GetButton("Fire1R") && Time.time > nextfire)
		{
			nextfire = Time.time + firerate;
			if(!playerCtr.facingLeft)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position,Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.tag = "playerL";
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.tag = "playerL";
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
