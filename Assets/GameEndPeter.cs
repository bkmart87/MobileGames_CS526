using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndPeter : MonoBehaviour {

	public Sprite[] Peter = new Sprite[7];

	// Use this for initialization
	void Start () {
		if(Statistics.grade>=1 && Statistics.grade<=7)
			gameObject.GetComponent<Image> ().sprite = Peter[Statistics.grade-1];
		else
			gameObject.GetComponent<Image> ().sprite = Peter[0];	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
