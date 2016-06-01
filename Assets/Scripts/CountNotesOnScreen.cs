using UnityEngine;
using System.Collections;

public class CountNotesOnScreen : MonoBehaviour 
{
	private GameObject [] arrayOfNotes; 
	private int activeNoteCount = 0; 
	// Use this for initialization
	void Start () 
	{
		arrayOfNotes = GameObject.FindGameObjectsWithTag("Notes");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		for(int i = 0; i < arrayOfNotes.Length; i++)
		{
			if (arrayOfNotes[i].transform.position.x < 5 && arrayOfNotes[i].activeSelf == true)
			{
				activeNoteCount ++; 
			}
		}
		print (activeNoteCount);
		if (activeNoteCount < 5)
		{
			switch (activeNoteCount)
			{
				case 0: 
				MoveChart.chartSpeed = -30;
				break;

				case 1: 
				MoveChart.chartSpeed = -25;
				break;

				case 2: 
				MoveChart.chartSpeed = -15;
				break;

				case 3: 
				MoveChart.chartSpeed = -7;
				break;

				case 4: 
				MoveChart.chartSpeed = -3;
				break;

			}
		}
		else
		{
			activeNoteCount = 0;
			MoveChart.chartSpeed = 0;
		}
	}
}
