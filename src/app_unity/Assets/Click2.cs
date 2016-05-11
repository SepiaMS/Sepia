using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Click2 : MonoBehaviour, IPointerClickHandler {
	public Click[] clicks;
	
	private string gameToPlay;
	
	public void OnPointerClick (PointerEventData eventData) {
		
		foreach (Click c in clicks) {
			if (c.Truc()) {
				
				UnityEngine.UI.Text questDescription = GameObject.Find("QuestScrollText").GetComponent<UnityEngine.UI.Text>();
				
				switch (c.name) {
					
				case "DEX":
					questDescription.text = "Un jeu de dextérité basé sur le jeu de la taupe : taper le plus vite possible sur des éléments surgissant de trous.";
					break;
				case "INT":
					gameToPlay = "Game_int";
					questDescription.text = "Un jeu de mémoire où vous devez reproduire une combinaison de couleurs jouée préalablement par l’application.";
					break;
				case "STA":
					questDescription.text = "Consultez ici votre score de mobilité, comptabilisé par l’application sur la base de votre nombre de pas.";
					break;
				case "STR":
					questDescription.text = "Un jeu de motricité où vous devez garder une bille en équilibre en plaçant votre téléphone parallèlement au sol.";
					break;
				case "WIS":
					gameToPlay = "Game_wisdom";
					questDescription.text = "Un jeu de concentration où vous devez toucher, dans l’ordre, les formes qui tombent de l’écran.";
					break;
					
				}
				
				return ;
			}
			else {
				
				if (gameToPlay == null) {
					Debug.LogWarning("`gameToPlay` field is empty; Clicking “Play” won’t do anything");
				} else {
					Button playButton = GameObject.Find("playButton").GetComponent<Button>();
					playButton.onClick.AddListener(delegate() { Application.LoadLevel(gameToPlay); });
				}

			}
		}
	}
}
