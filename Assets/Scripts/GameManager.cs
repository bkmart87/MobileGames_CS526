using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public string[] music;
	private int numNotesPerChart = 5;
	private int numOfCharts = 40;
	public GameObject chart;
	private GameObject charts;
	public GameObject note;

	public static float MAX_SPEED = 40.0f; // maximum moving speed of note
	public static float MIN_SPEED = 10.0f;  // min moving speed of note
	public static float MAX_CLICK_SPEED = 0.15f; // time spend from last click time to this click time
	public static float SLOPE = -30.0f;
	public static float lastClickTime = 0; //time last clicked 
	public static float clickSpeed = 0;   // time - lastClickTime 
	public static int numNotesPlayed = 0;
	public static int currentRound = 0;

	public static bool lastNotePlayed = false;

//	private Vector3 lowerLeft;
//	private Vector3 lowerRight;
//	private Vector3 topRightChart;
//
//	private float screenWidth = 0;
	private float clefWidth = 0.0f;

	private int[] noteOffsets = { 4, 8, 10, -2, 2, 0, -4, 6 };
//
//	private float chartWidth = 0;
//	private float chartHeight = 0;
//	private float chartRatio = 0;
//	private float actualChartWidth = 0;
//	private float actualChartHeight = 0;
//	private float chartScaleX = 0;
//	private float chartScaleY = 0;

	// Use this for initialization
	void Start () {
		// Get the lower left and lower right of screen
//		lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
//		lowerRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0));
//		screenWidth = lowerRight.x - lowerLeft.x;
//		chartWidth = screenWidth;
//		Debug.Log (lowerLeft);
//		Debug.Log(lowerRight);
//		Debug.Log("screenWidth:"+ screenWidth);
//		Debug.Log ("actualScreenWidth:" + Screen.width);


//		actualChartWidth = spriteRenderer.bounds.size.x;
//		actualChartHeight = spriteRenderer.bounds.size.y;
//		Debug.Log ("actual chart width" + actualChartWidth);
//		Debug.Log ("actual chart height" + actualChartHeight);

//		chartRatio = actualChartHeight / actualChartWidth;
//
//		topRightChart = Camera.main.ScreenToWorldPoint (new Vector3 (actualChartWidth, actualChartHeight,0));
//		chartHeight = chartWidth * chartRatio;
//		actualChartWidth = topRightChart.x - lowerLeft.x;
//		actualChartHeight = topRightChart.y - lowerLeft.y;
//
//
//		chartScaleX = chartWidth / actualChartWidth;
//		chartScaleY = chartHeight / actualChartHeight;

		music = new string[]{ "A", "B", "C", "D", "E", "F", "G"};
		Debug.Log ("music" + music);
		GameObject clef = GameObject.Find ("clef");
		SpriteRenderer clefSR = clef.GetComponent<SpriteRenderer> ();
		clefWidth = clefSR.bounds.size.x;
		Debug.Log (clefWidth);

		charts = GameObject.Find ("Charts");

		SpriteRenderer spriteRenderer = chart.GetComponent<SpriteRenderer> ();
		float width = spriteRenderer.sprite.bounds.size.x;
		Debug.Log("width" + width);
		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		Debug.Log ("screenH" + worldScreenHeight);
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		Debug.Log ("screenW" + worldScreenWidth);
		Vector2 chartScale = new Vector2 (1, 1) * (worldScreenWidth / width);
		Debug.Log (chartScale);

//		SpriteRenderer noteSR = note.GetComponent<SpriteRenderer> ();
//		float noteWidth = noteSR.sprite.bounds.size.x;
//		float noteWidth = note.GetComponent<RectTransform> ().position;
//		Vector2 noteScale = new Vector2 (1, 1) * (worldScreenWidth / 20.0f / noteWidth);

//		charts = new GameObject[numberOfCharts];

		float location = worldScreenWidth * 0.5f + clefWidth;

		for (int i = 0; i < numOfCharts; i++) {
			GameObject newChart = Instantiate (chart) as GameObject;
			Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 10));
			pos.x += location;
			pos.y +=  width / Screen.width * Screen.height + 5.0f;
			newChart.transform.position = pos;
			newChart.transform.localScale = chartScale;
			newChart.transform.parent = charts.transform;


			// create notes based on music
			float locationNote = location;
			for (int j = 0; j < numNotesPerChart; j++) {
				int key = Random.Range (0, 6);
				GameObject newNote = Instantiate (note) as GameObject;
				Vector3 posNote = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 10));
				posNote.x += locationNote;
				float offset = width / Screen.width * Screen.height + (float)key + 5.0f;
				posNote.y += offset;
				newNote.transform.position = posNote;
				newNote.transform.parent = charts.transform;
				locationNote += worldScreenWidth / 5.0f;

				newNote.GetComponent<PlayNote> ().semitone_offset = noteOffsets [key];

				newNote.transform.FindChild ("Text").GetComponent<TextMesh> ().text = music [key];

				if (i == numOfCharts - 1 && j == numNotesPerChart - 1) {
					newNote.GetComponent<PlayNote> ().thisIsLastKey = true;
				}
			}

			location += worldScreenWidth;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (GameManager.numNotesPlayed >= 25) {
//			charts.transform.position = new Vector3 (0, 15.5f, -10.0f);
//			GameManager.numNotesPlayed = 0;
//			GameManager.currentRound++;
//		}
//		Debug.Log ("numPlayed:" + GameManager.numNotesPlayed);
		if (GameManager.lastNotePlayed) {
			charts.transform.position = new Vector3 (0, 15.5f, -10.0f);
			GameManager.lastNotePlayed = false;
		}
	}

	void OnMouseDown(){

//		MoveCharts.chartMoveSpeed = calculateSpeed ();

	}

	public static float calculateSpeed(){
		GameManager.clickSpeed = Time.time - GameManager.lastClickTime;
		GameManager.lastClickTime = Time.time;	
		//Debug.Log (clickSpeed);
		float speed = GameManager.SLOPE*(GameManager.clickSpeed - GameManager.MAX_CLICK_SPEED) + GameManager.MAX_SPEED;
		if (speed > GameManager.MAX_SPEED)
			speed = GameManager.MAX_SPEED;
		if (speed < GameManager.MIN_SPEED)
			speed = GameManager.MIN_SPEED;
		Debug.Log (speed);
		return speed;
	}
}
