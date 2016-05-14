using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsUI : MonoBehaviour {

	public Text statDEX;
	public Text statINT;
	public Text statSTA;
	public Text statSTR;
	public Text statWIS;

	private GameInformation game;

	public void Start() {

		game = FindObjectOfType<GameInformation>();
		if (game == null) {
			Debug.LogWarning ("`GameInformation` gameObject not found");
		} else {
			game.load = FindObjectOfType<LoadInformation>();
			if (game.load == null) {
				Debug.LogWarning ("`LoadInformation` object not found – not added to `game.load`");
			}
		}

		updateUI ();

	}

	private void updateUI() {

		if (game == null || game.load == null) {
			Debug.LogError ("Cannot display actual statistics, as they cannot be loaded");
		} else {
			statDEX.text = game.load.GetStat (Sepia.stat.DEX).ToString ();
			statINT.text = game.load.GetStat (Sepia.stat.INT).ToString ();
			statSTA.text = game.load.GetStat (Sepia.stat.STA).ToString ();
			statSTR.text = game.load.GetStat (Sepia.stat.STR).ToString ();
			statWIS.text = game.load.GetStat (Sepia.stat.WIS).ToString ();
		}

	}

}
