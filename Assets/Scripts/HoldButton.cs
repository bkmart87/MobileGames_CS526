using UnityEngine;
using System.Collections;

public class HoldButton : MonoBehaviour {

	bool isBegin = false;
	float countTime = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isBegin) {
			countTime += Time.deltaTime;
		}
		if (countTime > 0.3f) {
			//Debug.Log ("Hold!");
		}
		
	
	}

	public void Down() {
		isBegin = true;
		Debug.Log ("Down");
	}

	public void Up() {
		isBegin = false;
		countTime = 0;
		Debug.Log ("Up");
	}

	public void Click() {
		//Debug.Log ("Click!");
	}
}
