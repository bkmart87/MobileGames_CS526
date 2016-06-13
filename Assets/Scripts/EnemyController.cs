using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 10f;
	Rigidbody2D myRB;


	void Awake() {
		myRB = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myRB.velocity = new Vector2 (speed, 0);
		//myRB.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
	}
}
