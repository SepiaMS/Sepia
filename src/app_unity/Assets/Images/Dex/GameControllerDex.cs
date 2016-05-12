using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControllerDex : MonoBehaviour {

	public Text		comboText;
	public Text		scoreText;
	public float	timer;
	public Text		timerText;
	public Text		yourturnText;
	public Text		endText;
	public Image	cooldown;


	public float    delay;			// time wait between show /hide sequence 

	public int		seqSize;
	private int[] 	seq; 			// sequence of pc generation
	private int 	countClick;
	private GameObject tmp;

	public Sprite spriteOff;
	public Sprite spriteOffUp;
	public Sprite spriteOn;
	public Sprite spriteOnUp;
	public Sprite spriteHight;
	public Sprite spriteHightUp;

	private float	cd; 			//for "sablier" set with timer
	private bool 	youturn = false;


	// Use this for initialization
	void Start () {
		cd = timer;						// init cooldown with timer public 
		seq = new int[seqSize];			// init size of sequence
		countClick = 0;					// TODO check if resart work
		SequenceStart ();
		StartCoroutine (showStart());

	
	}


	void endGame(){
			endText.text = "FIN";
	}

	// Update is called once per frame
	void Update (){

		if (youturn) {
			if (timer > 0) {	
				cooldown.fillAmount -= 1.0f / cd * Time.deltaTime; //fill sablier
				timer -= Time.deltaTime;
				Onclick();
			}else
				endGame();
		}
		printText ();
	}

	void Onclick(){


		if (Input.GetMouseButtonDown (0)) {

			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			
			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {
				print ("Onclick");
				Debug.Log (hit.collider.name);
				countClick++;
				StartCoroutine(showClick(int.Parse(hit.collider.name)));
			}
		}
	}

	void printText () {
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
	}

	private void SequenceStart() {
		for (int i = 0; i < seqSize; i++)
			seq [i] = Random.Range(1, 11); 				// random 1-6 generate sequence
	}

	void HiToOn(int iname){
		tmp = GameObject.Find(iname.ToString());
		if (iname % 2 == 0) {
			tmp.GetComponent<Image> ().sprite = spriteOnUp;
		}
		else
			tmp.GetComponent<Image> ().sprite = spriteOn;

	}

	void OffToHi(int iname){
		tmp = GameObject.Find(iname.ToString());
		if (iname % 2 == 0) {
			tmp.GetComponent<Image> ().sprite = spriteHightUp;
		}
		else
			tmp.GetComponent<Image> ().sprite = spriteHight;
	}

	void OnToOff(int iname){
		tmp = GameObject.Find(iname.ToString());
		if (iname % 2 == 0) {
			tmp.GetComponent<Image> ().sprite = spriteOffUp;
		}
		else
			tmp.GetComponent<Image> ().sprite = spriteOff;
	}

	IEnumerator showClick(int iname ){
		OffToHi (iname);
		yield return new WaitForSeconds (delay/2);
		HiToOn (iname);
		yield return new WaitForSeconds (delay);
	}

	
	IEnumerator showStart(){
		foreach (int iname in seq) {
			OnToOff (iname);
			yield return new WaitForSeconds (delay/2);
		}
	}
}
