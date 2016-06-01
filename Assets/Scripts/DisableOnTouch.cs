using UnityEngine;
using System.Collections;

public class DisableOnTouch : MonoBehaviour 
{
	public Sprite clickedSprite; 
	private Sprite unclickedSprite;
	// Use this for initialization
	void Awake()
	{
		unclickedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = clickedSprite; 
		Invoke("TurnOff", 0.2f);
	}

	void TurnOff()
	{
		this.gameObject.SetActive (false); 
		gameObject.GetComponent<SpriteRenderer>().sprite = unclickedSprite; 
	}
}
