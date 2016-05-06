using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour {

	public GameObject		prefab;											//item drop

	private int 			row;											//placement of drop in game
	
	public void DropItem (){
		row = Random.Range (-2, 2);											//row |-2 | -1 | 0 | 1 | 2 
		float pos = row * 1.1f;												//real position /!\ Warning Responsive
		Instantiate (prefab, new Vector2 (pos, 3.5f), Quaternion.identity);
	}
	
}
