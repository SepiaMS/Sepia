using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Sepia {
	
	public enum stat {
		NONE,

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
	
	public static GameInformation game;

	public LoadInformation load { get; set; }
	public SaveInformation save { get; set; }
	
	/// The player’s inventory
	public List<Sepia.item> inventory { get; set; }
	
	/// The player’s current score(s)
	public Dictionary<Sepia.stat, int> playerScore { get; set; }
	
	/**
	 * Methods
	 */
	
	// Keep this object in memory even in case of a new scene
	public void Awake() {
		
		if (game == null) {
			DontDestroyOnLoad (gameObject);
			game = this;
		} else if (game != this) {
			Destroy(gameObject);
		}
		
	}

	public void Start() {
		
		inventory = new List<Sepia.item>(Sepia.defaultInventory);
		
		// inventory.Add (Sepia.item.POTION_DEX);
		// …
		// foreach (Sepia.item invItem in inventory) {
		// 	print (invItem);
		// }
		
		
		playerScore = new Dictionary<Sepia.stat, int> ()
		{
			{ Sepia.stat.DEX, 0 },
			{ Sepia.stat.INT, 0 },
			{ Sepia.stat.STA, 0 },
			{ Sepia.stat.STR, 0 },
			{ Sepia.stat.WIS, 0 },
		};
		
	}
	
}

