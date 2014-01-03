using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	[HideInInspector]
	public int playerLeft = 0;
	[HideInInspector]
	public int playerRight = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print("asd");
		GetComponent<TextMesh>().text = playerLeft + " : " + playerRight;
	}
}
