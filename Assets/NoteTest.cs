using UnityEngine;
using System.Collections;

public class NoteTest : MonoBehaviour {
	Rigidbody2D myRb;

	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		myRb.velocity = new Vector2 (-10, myRb.velocity.y);
	}
}
