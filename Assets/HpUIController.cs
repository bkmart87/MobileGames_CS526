using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HpUIController : MonoBehaviour {
	int maxHp = 3;
	int hp = 3;
	public GameObject heartHp;
	public GameObject heartHpGrey;
	float initPosX = -229f;
	float gapX = 41f;
	GameObject[] hpArray = new GameObject[20];

	// Use this for initialization
	void Start () {
		GetHp ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < maxHp; i++) {
			
		}
	}

	public void addHp(int num) {
		hp += num;
		if (hp > maxHp)
			maxHp = hp;
		GetHp ();
	}

	public void GetHp() {
		for (int i = 0; i < maxHp; i++) {
			if (hpArray [i] != null) {
				Destroy (hpArray [i]);
			}
			if (i < hp) {
				hpArray [i] = Instantiate (heartHp);
			} else {
				hpArray [i] = Instantiate (heartHpGrey);
			}
			hpArray[i].transform.SetParent (gameObject.transform, false);
			hpArray [i].transform.localPosition = new Vector3 (initPosX + i * gapX, hpArray [i].transform.localPosition.y, hpArray [i].transform.localPosition.z);
		}
	}
}
