using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public float	timer;
	public Text		timerText;
	public Text		scoreText;
	public Text		comboText;
	public Image	cooldown;

	private bool	scoreSaved;
	private int		score;			// score to display
	private int		combo;			// combo to display
	private float	cd; 			//for "sablier" set with timer
	private Generation item;
	private float spawn = 0.0f;
	private GameInformation game;

	public bool c = true;
	// Use this for initialization
	void Start () {
		scoreSaved = false;
		combo = 0;
		score = 0;
		printText ();
		item = GetComponent<Generation> ();
		cd = timer;

		game = FindObjectOfType<GameInformation>();
		if (game == null) {
			Debug.LogError ("`GameInformation` gameObject not found");
		} else {
			game.save = FindObjectOfType<SaveInformation>();
			if (game.save == null) {
				Debug.LogError ("`SaveInformation` object not found – not added to `game.save`");
			}
		}

	}

	// Update is called once per frame
	void Update (){
		if (timer > 0) {
			cooldown.fillAmount -= 1.0f / cd * Time.deltaTime; //fill sablier
			timer -= Time.deltaTime;
			if (spawn > 1.0f) {
				item.DropItem ();
				spawn = 0.0f;
			}
			spawn += Time.deltaTime;
		} else {
			// Game is finished

			if (!this.scoreSaved) {
//				game.save.SaveStat();
				this.scoreSaved = true;
			}
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
		combo += 1;
		if (item.combo == false )
			combo = 0;
	}

}
