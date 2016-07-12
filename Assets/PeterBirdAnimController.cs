using UnityEngine;
using System.Collections;

public class PeterBirdAnimController : MonoBehaviour {
	public GameObject[] birds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FadeIn() {
		for (int i = 0; i < birds.Length; i++) {
			birds [i].GetComponent<Animator> ().SetTrigger ("FadeIn");
		}
	}

	public void FadeOut(bool isTrue) {
		for (int i = 0; i < birds.Length; i++) {
			birds [i].GetComponent<Animator> ().SetBool ("FadeOut", isTrue);
		}
	}
}
