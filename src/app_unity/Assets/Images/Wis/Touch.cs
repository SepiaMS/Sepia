 	using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {


	public Sprite spriteSuccess;
	
	private GameController gameController;
	private int scoreValue = 10 ;			//TODO add coefficien for lvl 
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update()
	{
		//If the left mouse button is clicked.
		if (Input.GetMouseButtonDown(0))
		{
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);
			
			//If something was hit, the RaycastHit2D.collider will not be null.
			if ( hit.collider != null )
			{
				if ( gameObject.GetComponent<item> ().ZoneClick == true){

					Debug.Log( hit.collider.name + "score value = " + scoreValue);
					gameController.addScore( scoreValue );	
					gameController.UpdateCombo();
					FindObjectOfType<Generation> ().combo = true;
					gameObject.GetComponent<SpriteRenderer> ().sprite = spriteSuccess;
					
			}
		}
	}

}

}