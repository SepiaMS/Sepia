using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public float	timer;
	public Text		timerText;
	public Text		scoreText;
	public Text		comboText;
	public Image	cooldown;


	private int		score;			// score to display
	private int		preScore;		// previous score for combo
	private int		combo;			// combo to display
	private float	cd; 			//for "sablier" set with timer
	private Generation item;
	private float spawn = 0.0f;

	// Use this for initialization
	void Start () {
		combo = 0;
		score = 0;
		preScore = 0;
		printText ();
		item = GetComponent<Generation> ();
		cd = timer;	
	}

	// Update is called once per frame
	void Update (){
		if (timer > 0) {	
			cooldown.fillAmount -= 1.0f/cd * Time.deltaTime; //fill sablier
			timer -= Time.deltaTime;
			if (spawn > 1.0f) {
				item.DropItem ();
				spawn = 0.0f;
			}
			spawn += Time.deltaTime;
		} 
		printText ();
	}

	void printText () {
		scoreText.text = "Score\n" + score.ToString();
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
		comboText.text = "Combo\n" + combo.ToString ();
	}

	public void addScore( int value ) {
		print ("Score = " + score + " & value = " + value);
		score += value;
 	}

	public void UpdateCombo ( ) {
		if (score > preScore) {
			combo += 1;
			preScore = score;
		} else
			combo = 0;
	}
}
