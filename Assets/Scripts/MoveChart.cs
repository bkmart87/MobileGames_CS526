using UnityEngine;
using System.Collections;

public class MoveChart : MonoBehaviour 
{
	public float tooFarLeft;
	public static float chartSpeed = 0f;
	public GameObject[] noteArray; 
	private Vector3 vSpeed, restart; 
	private float xMargin = 0.1f;


	// Use this for initialization
	void Start () 
	{
		restart = new Vector3(11.08f ,-1.72f, 0);

	}
	
	// Update is called once per frame
	void Update () 
	{
		vSpeed = new Vector3 (chartSpeed, 0, 0);
		if (Mathf.Abs(transform.position.x - tooFarLeft) < xMargin)
		{
			for(int i = 0; i < noteArray.Length; i++)
			{
				noteArray[i].SetActive (true); 
			}
			this.transform.position = restart; 
		}
		else 
		{
			this.transform.position += (vSpeed * Time.deltaTime);
		}
	}
}
