using UnityEngine;
using System.Collections;

public class SaveInformation : MonoBehaviour {

	public string statName;
	
	private GameInformation game;

	public void Start() {

		game = FindObjectOfType<GameInformation>();
		if (game == null) {
			Debug.LogWarning("The gameObject with `GameInformation` attached has not been found");
		}

	}

	public void SaveAllInformation() {
		
		// Need to “manually serialize” because dictionaries aren’t serializable
		this.SaveStat(Sepia.stat.DEX);
		this.SaveStat(Sepia.stat.INT);
		this.SaveStat(Sepia.stat.STA);
		this.SaveStat(Sepia.stat.STR);
		this.SaveStat(Sepia.stat.WIS);
		
	}

	public void SaveStat(int score) {

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
			Debug.LogError("Field “Stat Name” is empty");
		}

		if (stat_type != Sepia.stat.NONE) {
			this.game.playerScore[stat_type] = score;
			SaveStat(stat_type);
			Debug.LogFormat("Stat “{0}” saved (score: {1})", statName, score);
		} else {
			Debug.LogError("Stat has not been saved because it is not supported in this code.");
		}

	}
	
	private void SaveStat(Sepia.stat statType) {
		
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
			PlayerPrefs.SetInt (stat_name, this.game.playerScore[statType]);
		} else {
			Debug.LogWarningFormat("Stat has not been saved because it is not supported in this code.");
		}
	}
	
}

