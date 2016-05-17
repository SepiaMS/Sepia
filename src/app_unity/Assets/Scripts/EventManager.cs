using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{
	public delegate void ClickAction(string str);
	public static event ClickAction OnClicked;

	void OnGUI()
	{
		if (Input.GetMouseButtonDown (0)) {
			
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			if (hit.collider != null) {
				if(OnClicked != null)
					OnClicked(hit.collider.name.ToString());
			}
		}

	}
}