using UnityEngine;
using System.Collections;

public class SaveInformation : MonoBehaviour {
	
	public static void SaveAllInformation() {
		
		// Need to “manually serialize” because dictionaries aren’t serializable
		SaveStat(Sepia.stat.DEX);
		SaveStat(Sepia.stat.INT);
		SaveStat(Sepia.stat.STA);
		SaveStat(Sepia.stat.STR);
		SaveStat(Sepia.stat.WIS);
		
	}
	
	public static void SaveStat(Sepia.stat statType) {
		
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
			PlayerPrefs.SetInt (stat_name, GameInformation.info.playerScore [statType]);
		} else {
			Debug.LogWarningFormat("Stat has not been saved because it is not supported in this code.");
		}
	}
	
}

