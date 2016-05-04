using UnityEngine;
using System.Collections;

public class QuestMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadQuestByName(string quest)
	{
		Debug.Log ("Loading level “" + quest + "”");
		Application.LoadLevel (quest);
	}
}
