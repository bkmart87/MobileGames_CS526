using UnityEngine;
using System.Collections;

public class PeterBodyController : MonoBehaviour {

	public bool rbEnable = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			GetComponentInParent<Rigidbody2D> ().isKinematic = !rbEnable;
	}
}
