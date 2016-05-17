using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Statistics : MonoBehaviour {
	private LineRenderer lR;
	public List<Vector2> positions;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		positions = new List<Vector2>();
		positions.Add(new Vector2(1f,2f));
		positions.Add(new Vector2(1f,3f));
		positions.Add(new Vector2(2f,2f));
		positions.Add(new Vector2(2f,3f));
		lR = GetComponent<LineRenderer>();
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

		for(int p = 0; p < positions.Count;p++)
		{
			lR.SetPosition(p, positions[p]);
		}
		rend.material.mainTextureScale = new Vector2((int)Vector2.Distance(positions[0], positions[1]), 1);
	}
}