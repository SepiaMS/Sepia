using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Click2 : MonoBehaviour, IPointerClickHandler {
	public Click[] clicks;


	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log ("Hello");
		foreach (Click c in clicks) {
			if (c.Truc()) {
				Debug.Log("Good" + c.name);
				return ;
			}
			else {
//				Application.LoadLevel(c.level);
			}
		}
	}
}
