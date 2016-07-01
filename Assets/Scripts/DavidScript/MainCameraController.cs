using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public GameObject player;
	public GameObject bg;
	public GameObject newBg;
	public GameObject bgs;
	public bool generateItem;
	public GameObject violin;
	public int violinNum;
	public float violinProb;
	public GameObject rock;
	public int rockNum;
	public float rockProb;
	public GameObject heart;
	public int heartNum;
	public float heartProb;
	public GameObject boulder;
	public int boulderNum;
	public float boulderProb;
	public GameObject shield;
	public int shieldNum;
	public float shieldProb;

	float gapX = 87f;
	public float itemRange = 70f;

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
				GenerateItem (violin, bg, violinNum, itemRange, violinProb);
				GenerateItem (rock, bg, rockNum, itemRange, rockProb);
				GenerateItem (heart, bg, heartNum, itemRange, heartProb);
				GenerateItem (boulder, bg, boulderNum, itemRange, boulderProb);
				//GenerateItem (shield, bg, shieldNum, itemRange, shieldProb);
			}
		}
	}

	void GenerateItem(GameObject obj, GameObject parent, int num, float length, float prob) {// randomly generate items at parent 
		Random.seed = (int)System.DateTime.Now.Ticks;
		//Debug.Log ("Random.seed = " + Random.seed);
		float left = -length / 2f;
		float interval = length / num;
		for (int i = 0; i < num; i++) {
			if (Random.Range (0f, 1f) <= prob) {
				GameObject item = Instantiate (obj);
				item.transform.SetParent (parent.transform);
				float x = left + interval * Random.Range (0f, 1f);
				if (x < left + 20) // in case two item is too close
				left += 20; 
				item.transform.localPosition = new Vector3 (x, item.transform.localPosition.y, item.transform.localPosition.z);
				left += interval;
			}
		}
	}
}
