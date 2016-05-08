using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	 
//	public Sprite spriteSuccess;

	void OnTriggerEnter2D(Collider2D collider ) {
		print ("in zone\n");
		gameObject.GetComponent<item> ().ZoneClick = true;
//		gameObject.GetComponent<SpriteRenderer> ().sprite = spriteSuccess;
	}
}
