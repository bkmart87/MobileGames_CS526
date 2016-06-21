using UnityEngine;
using System.Collections;


[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;  //the offset that we don't get any wired errors


	//these are used for checking if we need to instantiate stuff
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;


	public bool reverseScale = false;  // used if the obhject is not tilable

	private float spriteWidth = 0f;  // the width of cut texture
	private Camera cam;
	private Transform myTransform;

	void Awake() {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {

		//checking doese it still need buddies? if fnot do nothing
		if (hasALeftBuddy == false || hasARightBuddy == false) {
			//callculate the cameras extend (half the width ) of what the camera can see in the world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			//calculate the x position where the camera can see the edge of the sprite(element)
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			//checking if we can see the edge of the element and then calling MakeNewBuddy if we can
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false) {
				MakeNewBuddy (1);
				hasARightBuddy = true;
			}
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false) {
				MakeNewBuddy (-1);
				hasALeftBuddy = true;
			}
			
		}


	}

	//a function that creates a buddy oon the side required
	void MakeNewBuddy (int rightOrLeft) {
		//calculating the position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		//instantiating our new body and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;


		// if not tilable let's reverse the x size orf our object to get rid of ugly seams;
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling> ().hasALeftBuddy = true;
		} else {
			newBuddy.GetComponent<Tiling> ().hasARightBuddy = true;
		}
	}
}
