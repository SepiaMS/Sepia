using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider ) {
		print ("in zone\n");
//		zone = true;
//		gameObject.GetComponent<SpriteRenderer> ().sprite = newSprite;
		//		gameObject.GetComponent<generate_drop> ().zone = true;
	}
}
