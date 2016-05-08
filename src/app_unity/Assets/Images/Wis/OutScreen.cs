using UnityEngine;
using System.Collections;

public class OutScreen : MonoBehaviour {

	void OnBecameInvisible()
	{
		DestroyObject(gameObject);
	}
}
