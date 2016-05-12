using UnityEngine;
using System.Collections;

public class GCWIS : GameController {

	private Generation item;
	private float spawn = 0.0f;
	
	// Use this for initialization
	void Start () {
		base.cd = timer;
		item = GetComponent<Generation> ();
		base.init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (base.CheckTimer ()) {
			Spawn ();
		}
		base.printText ();
	}

	void Spawn(){
		if (spawn > 1.0f) {
			item.DropItem ();
			spawn = 0.0f;
		}
		spawn += Time.deltaTime;
	}

	public void UpdateCombo ( ) {
		base.combo += 1;
		if (item.combo == false )
			base.combo = 0;
	}
}

