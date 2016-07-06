using UnityEngine;
using System.Collections;

public class DestController : MonoBehaviour {
	GameObject game;
	public GameObject flag;
	Animator flagAnim;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Game");
		flagAnim = flag.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the destination and then "you win".
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			flag.SetActive (true);
			flagAnim.SetBool ("Win", true);
			game.GetComponent<GameController>().GameWin();
		}
	}
}
