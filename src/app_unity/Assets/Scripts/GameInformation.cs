using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Sepia {

	public enum stat {
		DEX,
		INT,
		STA,
		STR,
		WIS,
	}

	public enum item {
		COLOR_Sepia,
		
		POTION_DEX,
		POTION_INT,
		POTION_STA,
		POTION_STR,
		POTION_WIS,
		
		RECIPE_RELAXATION,
		RECIPE_SLEEP,
	}

	public static item[] defaultInventory = {
		item.POTION_DEX,
		item.POTION_INT,
		item.POTION_STA,
		item.POTION_STR,
		item.POTION_WIS,
		
		item.RECIPE_RELAXATION,
		item.RECIPE_SLEEP,
	};

}

public class GameInformation : MonoBehaviour {

	/**
	 * Attributes
	 */

	// The player’s inventory
	public List<Sepia.item> inventory;

	// The player’s current score(s)
	public Dictionary<Sepia.stat, int> playerScore;


	/**
	 * Methods
	 */
	
	public GameInformation() {

		inventory = new List<Sepia.item>(Sepia.defaultInventory);

		// inventory.Add (Sepia.item.POTION_DEX);
		// …
		// foreach (Sepia.item it in inventory) {
		// 	print (it);
		// }


		Dictionary<Sepia.stat, int> playerScore = new Dictionary<Sepia.stat, int>();

		playerScore.Add(Sepia.stat.DEX, 0);
		playerScore.Add(Sepia.stat.INT, 0);
		playerScore.Add(Sepia.stat.STA, 0);
		playerScore.Add(Sepia.stat.STR, 0);
		playerScore.Add(Sepia.stat.WIS, 0);

	}

	// Keep this object in memory even in case of a new scene
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
	
}
