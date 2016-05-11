using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControllerInt : MonoBehaviour {

	public float	timer;
	public Text		timerText;
	public Text		yourturnText;
	private float	cd; 			//for "sablier" set with timer
	public Image	cooldown;


	public float    delay;
	private bool 	youturn = false;
	public int		seqSize;
	public GameObject test;
	public Sprite spriteSuccess;
	public Sprite sprite;
	int[] seq;
	// Use this for initialization
	void Start () {
		cd = timer;
		printText ();
		seq = new int[seqSize];
		SequenceDemo ();
		StartCoroutine ("showSequence");
	}

	// Update is called once per frame
	void Update (){
		if (youturn) {
			if (timer > 0) {	
				cooldown.fillAmount -= 1.0f / cd * Time.deltaTime; //fill sablier
				timer -= Time.deltaTime;
			}
		}
		printText ();
	}


	void printText () {
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
	}

	public void SequenceDemo() {
		for (int i = 0; i < seqSize; i++)
			seq [i] = Random.Range(1, 7);
	}


	IEnumerator showSequence()
	{
		foreach (int iname in seq) {
			ShowSprite ((int)iname);
			yield return new WaitForSeconds (delay);
			HideSprite ((int)iname);
		}
		youturn = true;
		yourturnText.text = "Your Turn";


	}

	void ShowSprite(int iname){
		test = GameObject.Find(iname.ToString());
		test.GetComponent<Image> ().sprite = spriteSuccess;
	}

	void HideSprite(int iname){
		test = GameObject.Find(iname.ToString());
		test.GetComponent<Image> ().sprite = sprite;
	}

}
