using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public GameObject player;
	public GameObject bg;
	public GameObject newBg;
	public GameObject bgs;
	public GameObject violin;
	public GameObject rock;
	public GameObject heart;
	public GameObject boulder;
	public bool generateItem;
	float gapX = 87f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.localPosition;
		transform.localPosition = new Vector3(player.transform.localPosition.x, pos.y, pos.z);
		if (GetComponent<Camera> ().WorldToViewportPoint (bg.transform.position).x < 0.5f) { //dynamic generate new background when camera arrive the center of the current background
			float oldX = bg.transform.localPosition.x;
			bg = Instantiate (newBg);
			bg.transform.SetParent (bgs.transform);
			float newX = oldX + gapX;
			bg.transform.localPosition = new Vector3 (newX, bg.transform.localPosition.y, bg.transform.localPosition.z);

			//generate all items in new background
			if (generateItem) {
				GenerateItem (violin, bg, 1, gapX, false);
				GenerateItem (rock, bg, 3, gapX, true);
				GenerateItem (heart, bg, 2, gapX, true);
				GenerateItem (boulder, bg, 2, gapX, true);
			}
		}
	}

	void GenerateItem(GameObject obj, GameObject parent, int num, float length, bool isRandomNum) {// randomly generate items at parent 
		Random.seed = (int)System.DateTime.Now.Ticks;
		//Debug.Log ("Random.seed = " + Random.seed);
		if(isRandomNum) num = (int)Random.Range(0f, num + 0.9f);
		float left = -length / 2f;
		float interval = length / num;
		for (int i = 0; i < num; i++) {
			GameObject item = Instantiate (obj);
			item.transform.SetParent (parent.transform);
			float x = left + interval * Random.Range (0f, 1f);
			if (x < left + 20) // in case two item is too close
				left += 30; 
			item.transform.localPosition = new Vector3 (x, item.transform.localPosition.y, item.transform.localPosition.z);
			left += interval;
		}
	}
}
