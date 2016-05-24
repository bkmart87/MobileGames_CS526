using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour 
{
	public string levelName ="Level0"; 

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel(levelName); 
		}
	}
}
