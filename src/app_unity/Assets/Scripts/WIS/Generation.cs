using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour {

	public GameObject		prefab;											//item drop
	
	private int 			row;											//placement of drop in game
	private int				rename = 0;
	public bool 			combo;

	void Start(){
		rename = 0;
		prefab.tag = "piece"; 
		combo = true;

	}

	public void DropItem (){
		rename++;
		row = Random.Range (-2, 2);											//row |-2 | -1 | 0 | 1 | 2 
		float pos = row * 1.1f;												//real position /!\ Warning Responsive
		Object piece = Instantiate (prefab, new Vector2 (pos, 3.5f), Quaternion.identity);
		piece.name = rename.ToString();
	}
	
}
