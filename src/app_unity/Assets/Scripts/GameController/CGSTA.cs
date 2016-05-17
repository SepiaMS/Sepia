using UnityEngine;
using System.Collections;

public class CGSTA : GameController {


	// Use this for initialization
	void Start () {
		base.cd = timer;
		base.init ();
		base.score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (base.CheckTimer ()) {
			base.Onclick ();
		}
		
		base.printText ();
	}


}
