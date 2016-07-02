using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCameraController : MonoBehaviour {

	public GameObject player;
	public GameObject bg;
	public GameObject newBg;
	public GameObject bgs;
	public bool generateItem;
	public bool generateObstacle;
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


	float gapX = 152f;
	public float itemRange = 70f;

	List<GameObject> obstacleList = new List<GameObject>();
	List<int> obstacleNumList = new List<int>();
	List<float> obstacleProbList = new List<float> ();
	List<int> obstacleIndexList = new List<int> ();


	// Use this for initialization
	void Start () {
		obstacleList.Add (rock);
		obstacleList.Add (boulder);
		obstacleNumList.Add (rockNum);
		obstacleNumList.Add (boulderNum);
		obstacleProbList.Add (rockProb);
		obstacleProbList.Add (boulderProb);


		for (int i = 0; i < obstacleList.Count; i++) {
			for (int j = 0; j < obstacleNumList [i]; j++) {
				obstacleIndexList.Add (i);
			}
		}


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
				GenerateItem (violin, bg, violinNum, gapX, violinProb);
				GenerateItem (heart, bg, heartNum, gapX, heartProb);
				GenerateItem (shield, bg, shieldNum, gapX, shieldProb);
			}
			if (generateObstacle) {
				GenerateObstacle (bg, gapX);
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
				float x = left + interval * Random.Range (0.3f, 0.7f);
				item.transform.localPosition = new Vector3 (x, item.transform.localPosition.y, item.transform.localPosition.z);

			}
			left += interval;
		}
	}

	void GenerateObstacle(GameObject parent, float length) {
		Random.seed = (int)System.DateTime.Now.Ticks;
		int total = obstacleIndexList.Count;
		for (int i = 0; i < total; i++) {
			int k = (int)Random.Range (0, total - 0.1f);
			int temp = obstacleIndexList [k];
			obstacleIndexList [k] = obstacleIndexList[i];
			obstacleIndexList [i] = temp;
		}
		float left = -length / 2f;
		float interval = length / total;
		for (int i = 0; i < total; i++) {
			int index = obstacleIndexList [i];
			if (Random.Range (0f, 1f) <= obstacleProbList[index]) {
				GameObject obstacle = Instantiate (obstacleList[index]);
				obstacle.transform.SetParent (parent.transform);
				float x = left + interval * Random.Range (0.3f, 0.7f);
				obstacle.transform.localPosition = new Vector3 (x, obstacle.transform.localPosition.y, obstacle.transform.localPosition.z);

			}
			left += interval;
		}

	}

}
