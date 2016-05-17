using UnityEngine;
using System.Collections;

public class EventSeq : MonoBehaviour 
{
	void OnEnable()
	{
		EventManager.OnClicked += ResetCoroutine;
	}
	
	
	void OnDisable()
	{
		EventManager.OnClicked -= ResetCoroutine;
	}

	void ResetCoroutine(string str)
	{
			if (str == this.name && this.GetComponent<Down> ().on == true) {
				StartCoroutine (GetComponent<Down> ().Reset ());
			}
	}

	bool checkOk(){
		return false;
	}

}