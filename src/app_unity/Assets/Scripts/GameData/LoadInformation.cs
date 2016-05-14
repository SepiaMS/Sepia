using UnityEngine;
using System.Collections;

public class LoadInformation : MonoBehaviour {
	
	private GameInformation game;
	
	public void Start() {
		
		game = FindObjectOfType<GameInformation>();
		if (game == null) {
			Debug.LogWarning("The gameObject with `GameInformation` attached has not been found");
		}
		
	}
	
	public int GetStat(string statName) {
		
		Sepia.stat stat_type = Sepia.stat.NONE;
		
		if (statName != null) {
			if (statName.Contains ("DEX")) {
				stat_type = Sepia.stat.DEX;
			} else if (statName.Contains ("INT")) {
				stat_type = Sepia.stat.INT;
			} else if (statName.Contains ("STA")) {
				stat_type = Sepia.stat.STA;
			} else if (statName.Contains ("STR")) {
				stat_type = Sepia.stat.STR;
			} else if (statName.Contains ("WIS")) {
				stat_type = Sepia.stat.WIS;
			}
		} else {
			Debug.LogError("Parameter “Stat Name” is empty");
		}
		
		if (stat_type != Sepia.stat.NONE) {
			return GetStat (stat_type);
		} else {
			Debug.LogError("Stat has not been loaded because it is not supported in this code. Returned 0.");
			return 0;
		}
		
	}
	
	public int GetStat(Sepia.stat statType) {
		
		string stat_name = null;
		
		switch (statType) {
		case Sepia.stat.DEX:
			stat_name = "STAT_DEX";
			break;
		case Sepia.stat.INT:
			stat_name = "STAT_INT";
			break;
		case Sepia.stat.STA:
			stat_name = "STAT_STA";
			break;
		case Sepia.stat.STR:
			stat_name = "STAT_STR";
			break;
		case Sepia.stat.WIS:
			stat_name = "STAT_WIS";
			break;
		}
		
		if (stat_name != null) {
			return PlayerPrefs.GetInt (stat_name, this.game.playerScore[statType]); // If `stat_name` not found, the default value is today’s `playerScore`
		} else {
			Debug.LogWarningFormat("Stat has not been loaded because it is not supported in this code. Returned 0.");
			return 0;
		}
	}
	
}

