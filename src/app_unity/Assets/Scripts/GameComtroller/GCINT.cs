using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GCINT : GameController {

	public Text		yourturnText;
	public Text		endText;

	public float    delay;			// time wait between show /hide sequence 

	public int		seqSize;
	private int[] 	seq; 			// sequence of pc generation
	private int[] 	seqPlayer; 		// sequence of Player


	private int 	countClick;
	private GameObject tmp;

	public Sprite spriteSuccess;
	public Sprite spriteSuccessUp;
	public Sprite spriteUp;
	public Sprite sprite;

	private bool 	youturn = false;


	// Use this for initialization
	void Start () {
		base.cd = timer;
		seq = new int[seqSize];			// init size of sequence
		seqPlayer = new int[seqSize];
		SequenceDemo ();				// init sequence 
		countClick = 0;					// TODO check if resart work
		StartCoroutine ("showSequence");
	}

	bool checkSeq(){
		for (int i = 0; i < seqSize; i++) {
			if (seqPlayer[i] != seq[i])
				return false;
		}
		return true;
	}

	void endGame(){
		youturn = false;
		if (checkSeq())
			endText.text = "GAGNER";
		else 
			endText.text = "PERDU";
	}

	// Update is called once per frame
	void Update (){
		if (youturn) {
			base.CheckTimer();
			if (countClick == seqSize  ){
				print ("tmp END GAME count " + countClick + "seqSize = " + seqSize);
				endGame();
			}
			else
				Onclick();
			}
		base.printText ();
	}

	void Onclick(){


		if (Input.GetMouseButtonDown (0)) {

			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			
			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {
				print ("Onclick");
				seqPlayer[countClick] = int.Parse(hit.collider.name); 
				Debug.Log (hit.collider.name);
				countClick++;
				StartCoroutine(showClick(int.Parse(hit.collider.name)));
			}
		}
	}

	private void SequenceDemo() {
		for (int i = 0; i < seqSize; i++)
			seq [i] = Random.Range(1, 7); 				// random 1-6 generate sequence
	}

	void ShowSprite(int iname){
		tmp = GameObject.Find(iname.ToString());
		if (tmp.name == "6") {
			tmp.GetComponent<Image> ().sprite = spriteSuccessUp;
		}
		else
			tmp.GetComponent<Image> ().sprite = spriteSuccess;

	}

	void HideSprite(int iname){
		tmp = GameObject.Find(iname.ToString());
		if (tmp.name == "6")
			tmp.GetComponent<Image> ().sprite = spriteUp;
		else 
			tmp.GetComponent<Image> ().sprite = sprite;
	}

	IEnumerator showClick(int iname ){
		ShowSprite (iname);
		yield return new WaitForSeconds (delay/2);
		HideSprite (iname);
		yield return new WaitForSeconds (delay/4);
	}
	
	IEnumerator showSequence()
	{
		foreach (int iname in seq) {
			ShowSprite ((int)iname);
			yield return new WaitForSeconds (delay);
			HideSprite ((int)iname);
			yield return new WaitForSeconds (delay/2); // if not add delay we dont see twice in row 
		}
		youturn = true;
		yourturnText.text = "Your Turn";
	}
}
