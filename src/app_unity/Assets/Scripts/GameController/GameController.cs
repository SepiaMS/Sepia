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
	protected int		score;			// score to display
	protected int		combo;			// combo to display
	protected float	cd; 			//for "sablier" set with timer

	private GameInformation game;

//	public bool c = true;
	// Use this for initialization
	void Start () {
		scoreSaved = false;
		combo = 10;
		score = 10;
		printText ();

		cd = timer;

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
		print ("update GameCOntroler");
		CheckTimer ();
		printText ();
	}

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
				GameInformation.game.playerScore[Sepia.stat.WIS] = score;
				this.scoreSaved = true;
			}

		}
		return false;
	}

	public void printText () {
		if (scoreText != null)
			scoreText.text = "Score\n" + score.ToString();
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
		if (comboText != null)
			comboText.text = "Combo\n" + combo.ToString ();
	}

	public void addScore( int value ) {
		print ("Score = " + score + " & value = " + value);
		score += value;
 	}


//	public void Onclick(){
//		
//		
//		if (Input.GetMouseButtonDown (0)) {
//			
//			//Get the mouse position on the screen and send a raycast into the game world from that position.
//			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
//			
//			//If something was hit, the RaycastHit2D.collider will not be null.
//			if (hit.collider != null) {
//				print ("Onclick");
//				seqPlayer[countClick] = int.Parse(hit.collider.name); 
//				Debug.Log (hit.collider.name);
//				countClick++;
//				StartCoroutine(showClick(int.Parse(hit.collider.name)));
//			}
//		}
//	}


}
