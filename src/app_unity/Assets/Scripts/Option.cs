using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Option : MonoBehaviour {

	public string type;
	public string target;
	private Slider obj_slider;
	private AudioSource obj_audio_music;

	public void ft_slider_value_changed_action()
	{
		switch (type)
		{
		case "Slider":
			obj_audio_music = GameObject.FindWithTag(target).GetComponent<AudioSource>();
			obj_slider = this.gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>();
			obj_audio_music.volume = obj_slider.value;
			break;
		}
	}
}
