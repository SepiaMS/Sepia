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
	protected int	score;			// score to display
	protected int	combo;			// combo to display
	protected float	cd; 			//for "sablier" set with timer

	private GameInformation game;

//	public bool c = true;
	// Use this for initialization
	void Start () {
		scoreSaved = false;
		combo = 0;
		score = 0;
		printText ();

		cd = timer;

	}

	protected void init() {
		
		game = FindObjectOfType<GameInformation>();
		if (game == null) {
			Debug.LogWarning ("`GameInformation` gameObject not found");
		} else {
			game.save = FindObjectOfType<SaveInformation>();
			if (game.save == null) {
				Debug.LogWarning ("`SaveInformation` object not found – not added to `game.save`");
			}
		}

	}

	// Update is called once per frame
	void Update (){
		CheckTimer ();
		printText ();
	}

//	//	replace CheckTimer par EndGame
//	protected bool EndGame(){
//		if (CheckTimer ())
//			return true;
//		else
//			return false; 
//	}

	public void CD(){
		cooldown.fillAmount -= 1.0f / cd * Time.deltaTime; //fill sablier
		timer -= Time.deltaTime;
	}

	public bool CheckTimer(){
		if (timer > 0) {
			cooldown.fillAmount -= 1.0f / cd * Time.deltaTime; //fill sablier
			timer -= Time.deltaTime;
			return true;
		} else {
			// Game is finished
			if (!this.scoreSaved) {
				GameInformation.game.save.SaveStat(score);
				this.scoreSaved = true;
			}

		}
		return false;
	}

	public void printText () {
		if (scoreText != null) {
			scoreText.text = "Score\n" + score.ToString ();
		}
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
		if (comboText != null)
			comboText.text = "Combo\n" + combo.ToString ();
	}

	public void addScore( int value ) {
		//print ("Score = " + score + " & value = " + value);
		score += value;
 	}


	public bool Onclick(){
		
		if (Input.GetMouseButtonDown (0)) {
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			if (hit.collider != null)
				return true;
		}
		return false;
	}


}
