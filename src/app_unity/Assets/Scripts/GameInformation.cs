using UnityEngine;
using System.Collections;

public abstract class SepiaLogic {

	public enum item {
		NOTHING,
		
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

	// Keep this object in memory even in case of a new scene
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	// The player’s inventory
	public static item[] inventory { get; set; }
	

	/*
	 * Player current scores for each Quest
	 */
	[DefaultValue(0)]
	public static int playerScoreDEX { get; set; }

	[DefaultValue(0)]
	public static int playerScoreINT { get; set; }

	[DefaultValue(0)]
	public static int playerScoreSTA { get; set; }

	[DefaultValue(0)]
	public static int playerScoreSTR { get; set; }

	[DefaultValue(0)]
	public static int playerScoreWIS { get; set; }


	// Set some default values to objects created
	public GameInformation() {

		SepiaLogic.item[] inventory = SepiaLogic.defaultInventory;

	}
	
}
