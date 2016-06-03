using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (0, 0, 2);
		//transform.Translate(0.1f, 0,0);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (1 * speed, 0);
	}
}
