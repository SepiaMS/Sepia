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
					gameObject.GetComponent<SpriteRenderer> ().sprite = spriteSuccess;
					
//				}
			}
		}
	}

}

}

/*
 * 
 * 
 * void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//			print (hit);
			if (hit){
//				Debug.Log (hit.collider.gameObject.name);

				if ( gameObject.GetComponent<item> ().ZoneClick == true)
				{
					gameController.addScore( scoreValue );	
//					gameObject.GetComponent<SpriteRenderer> ().sprite = spriteSuccess;

//					 gameObject.GetComponent<GameControler> ().addScore(10);
					// GameControler.addScore( 10 );
//					DestroyObject(gameObject);
				}


			}
			else
				Debug.Log ("pas de collisions");
			
		}
	}

*/