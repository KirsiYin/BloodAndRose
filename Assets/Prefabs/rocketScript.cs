using UnityEngine;
using System.Collections;

public class rocketScript : MonoBehaviour {
	public GameObject explosion;

	private Score score;
	// Use this for initialization
	Animator anim;
	void Start () {

		anim = GetComponent<Animator>();
		Destroy(gameObject, 2);
	}
	void Awake()
	{
		// Setting up the references

	}
	// Update is called once per frame
	void Update () {
	}
	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
//		
//		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	void OnTriggerEnter2D (Collider2D col) 
	{

		//Destroy (gameObject);
		// If it hits an enemy...
		if (col.tag == gameObject.tag) {
			print (gameObject.tag + " : " + col.tag);
			//anim.SetTrigger("destroy");
			// ... find the Enemy script and call the Hurt function.
			//col.gameObject.GetComponent<playerLScript>().Hurt();

			// Call the explosion instantiation.
			OnExplode ();
			//score = transform.root.GetComponent<Score>();
			//print(score.playerLeft);
//			if(col.tag.Equals("playerR")){
//				score.playerLeft = score.playerLeft + 1;
//			}else{
//				score.playerRight = score.playerRight + 1;
//			}

			// Destroy the rocket.
			Destroy (col.gameObject);
			Destroy (gameObject);
		} else if(!col.tag.Contains("player")){
			OnExplode ();
			Destroy (gameObject);
		}
	}
}
