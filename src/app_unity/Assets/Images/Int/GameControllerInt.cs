using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControllerInt : MonoBehaviour {

	public float	timer;
	public Text		timerText;
	private float	cd; 			//for "sablier" set with timer
	public Image	cooldown;


	public float    delay = 1.0f;
	public GameObject test;
	public Sprite spriteSuccess;
	static int  iseq = 0;
	// Use this for initialization
	void Start () {
		cd = timer;
		printText ();
		SequenceDemo();
	}

	// Update is called once per frame
	void Update (){
		SequenceDemo();
//		test.GetComponent<SpriteRenderer>().sprite = spriteSuccess;
		
		if (timer > 0) {	
			cooldown.fillAmount -= 1.0f/cd * Time.deltaTime; //fill sablier
			timer -= Time.deltaTime;
		} 
		printText ();
		test = GameObject.Find("1");
	}


	void printText () {
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
	}

	public void SequenceDemo() {
		print (delay + " i " + iseq);
		int[] seq = new int[5];
		for (int i =0; i < 5; i++)
			seq [i] = Random.Range(1, 7);

		if (delay > 0) {
			delay -= Time.deltaTime;
		}
		else {
			showSequence (seq[iseq]);
			delay = 1.0f;
			iseq++;
		}
	}

	private int showSequence(int e){

		test = GameObject.Find(e.ToString());
		test.GetComponent<Image> ().sprite = spriteSuccess;
		print ("e = " + e.ToString());
		return 0;
	}
}
