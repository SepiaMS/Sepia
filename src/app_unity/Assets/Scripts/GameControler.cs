using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControler : MonoBehaviour {

	public float	timer;
	public Text		timerText;
	public Text		scoreText;
	public Text		comboText;

	private int		score;	
	private int		combo;

	private Generation item;
	private float spawn = 0.0f;

	// Use this for initialization
	void Start () {
		combo = 0;
		score = 0;
		printText ();
		item = GetComponent<Generation> ();
		
	}

	// Update is called once per frame
	void Update (){
		if (timer > 0) {
			timer -= Time.deltaTime;
			if ( spawn > 1.0f){
				item.DropItem(  );
				spawn = 0.0f;
			}
			spawn += Time.deltaTime;
			printText ();
		}
		score += 1;

	}

	void printText () {
		scoreText.text = "Score\n" + score.ToString();
		if (timer <= 0)
			timer = 0;
		timerText.text = timer.ToString ("0.00");		// "0:00:00" format is possible 
		comboText.text = "Combo\n" + combo.ToString ();
	}


}
