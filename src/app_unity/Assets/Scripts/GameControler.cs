using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControler : MonoBehaviour {

//	public float	timer;

//	private Text	timerText;
	private Text	scoreText;
//	private Text	comboText;
	private int		score;
//	private int		combo;


	// Use this for initialization
	void Start () {
		score = 0;
//		combo = 0;
//		if (timer == null)
//			timer = 60.0f;
	}

	// Update is called once per frame
	void Update (){
		score += 1;
		scoreText.text = "Score: " + score.ToString();
//		timer -= Time.deltaTime;
	}
	void UpdateScore () {
		
	}


}
