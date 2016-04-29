using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	
	public GameObject loadingImage = null;

	public void enableLoadingImage()
	{
		if (loadingImage) {
			loadingImage.SetActive (true);
		}
	}
	
	public void LoadScene(int level)
	{
		this.enableLoadingImage();
		Debug.Log ("Loading level #" + level);
		Application.LoadLevel (level);
	}

	public void LoadSceneByName(string level)
	{
		this.enableLoadingImage();
		Debug.Log ("Loading level “" + level + "”");
		Application.LoadLevel (level);
	}

}