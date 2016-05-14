using UnityEngine;
using System.Collections;

public class CGDEX : GameController {

	public GameObject		UpPrefab;
	public GameObject		DownPrefab;

	public Transform[] tpts = new Transform[10];
	private GameObject[] tPrefabs = new GameObject[10];

	// TODO FOR DEBUG
	public int dexScore;


	// Use this for initialization
	void Start () {
		base.cd = timer;
		base.init ();
		base.score = 0;
		initPrefab ();

	}
	
	// Update is called once per frame
	void Update () {
		if (base.CheckTimer ()) {
			Onclick ();
		}
		ScoreUpdate ();
		base.printText ();
	}

	void initPrefab(){
		for (int i = 0; i < 10; i++) {
			if (tpts != null) {
				tPrefabs[i] = (GameObject)Instantiate (DownPrefab, tpts[i].position, tpts[i].rotation);
				tPrefabs[i].GetComponent<Down>().deadTime = Random.Range(1, 6);							//set timer while sprite is off
				tPrefabs[i].name = i.ToString();														//rename prefab	
			}
		}
	}

	void ScoreUpdate(){
		int s = 0;
		for (int i = 0; i < 10; i++) {
			s += tPrefabs[i].GetComponent<Down>().score;
		}
		if ((s / 4)  > dexScore) //call 4 time each i dont know why
			dexScore = s / 4;
		base.score = dexScore;
	}

	//TODO move this fonction to GameControler
	void Onclick(){
		
		if (Input.GetMouseButtonDown (0)) {
			
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			
			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {
				Debug.Log (hit.collider.name);


				//				StartCoroutine(showClick(int.Parse(hit.collider.name)));
				
				
			}
		}
	}

}
