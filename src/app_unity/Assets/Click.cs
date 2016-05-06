using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour {
	public Sprite sprite;
	public string level;

	public bool Truc() {
		Vector3 pos = transform.InverseTransformPoint (Input.mousePosition);
		RectTransform rect = GetComponent<RectTransform> ();
		pos += new Vector3 (rect.pivot.x * rect.rect.width, rect.pivot.y * rect.rect.height);
		Debug.Log (pos + " " + rect.rect.width);
		if (pos.x < 0 || pos.x >= rect.rect.width || pos.y < 0 || pos.y >= rect.rect.height || sprite.texture.GetPixel ((int)pos.x, (int)pos.y).a == 0) {
			return false;
		}
		return true;
	}
}
