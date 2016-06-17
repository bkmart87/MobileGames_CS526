using UnityEngine;
using System.Collections;

public class destController : MonoBehaviour {
	public playerController pc = null;
	public EnemyController ec = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			//Destroy (gameObject);
			//playerController.currentSpeed = 0f;
			//Debug.Log("Hit");
			//pc.Stop ();
			//ec.Stop ();
			GameController.GameWin();

		}
	}
}
