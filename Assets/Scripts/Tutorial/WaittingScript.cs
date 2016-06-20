using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaittingScript : MonoBehaviour {

	public Text text;

	public void waittingMess(){
		text.text = "Waitting...";	
	}

}
