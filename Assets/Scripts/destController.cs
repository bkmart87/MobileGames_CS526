using UnityEngine;
using System.Collections;

public class destController : MonoBehaviour {
	public playerController pc = null;
	public EnemyController ec = null;
	bool win = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			GameObject.Find("Game").GetComponent<GameController>().GameWin();
		}
	}
}
