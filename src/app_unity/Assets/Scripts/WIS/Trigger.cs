using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	 
//	public Sprite spriteSuccess;

	void OnTriggerEnter2D(Collider2D collider ) {
		print ("in zone\n");
		gameObject.GetComponent<item> ().ZoneClick = true;
//		gameObject.GetComponent<SpriteRenderer> ().sprite = spriteSuccess;
	}

	void OnTriggerExit2D(Collider2D collider ) {
		if (gameObject.GetComponent<SpriteRenderer> ().sprite.name != "wis success") { // wis succuess warning name of srpite
			print ("On triger exit : wis succuessKO ");
			FindObjectOfType<Generation> ().combo = false;
			FindObjectOfType<GCWIS>().UpdateCombo();
		}
	}
}
