using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
		this.gameObject.GetComponent<AudioSource>().Play();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
