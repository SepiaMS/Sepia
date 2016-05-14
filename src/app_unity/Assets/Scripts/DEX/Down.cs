using UnityEngine;
using System.Collections;

public class Down : MonoBehaviour {

	public Sprite	spriteOff;
	public Sprite	spriteOn;
	public Sprite	spriteHight;

	public float	lifeTime;
	public float	popTime;
	public float	deadTime;

	public bool		on;
	public int		score;

	// Use this for initialization
	void Start () {
		StartCoroutine (Dead ());
	}

	IEnumerator Pop(){
		on = true;
		this.GetComponent<SpriteRenderer> ().sprite = spriteHight;
		yield return new WaitForSeconds (popTime);
		this.GetComponent<SpriteRenderer> ().sprite = spriteOn;
		yield return new WaitForSeconds (lifeTime);
		StartCoroutine (Dead ());
	}

	IEnumerator Dead(){
		on = false;
		this.GetComponent<SpriteRenderer> ().sprite = spriteOff;
		yield return new WaitForSeconds (deadTime);
		StartCoroutine (Pop ());
	}
		   
	public IEnumerator Reset(){
		this.score += 1;
		this.GetComponent<SpriteRenderer> ().sprite = spriteOff;
		this.StopAllCoroutines();
		yield return new WaitForSeconds (1);
		StartCoroutine (Dead ());
		
	}
}
