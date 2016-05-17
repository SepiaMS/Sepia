using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour
{
	public GameObject obj_user_interface;

	void Start()
	{
		obj_user_interface = GameObject.FindWithTag ("UserInterface");
	}

	public void ft_audio_stop_all()
	{
		AudioSource[] arr_obj_audio;

		{
			arr_obj_audio = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
			foreach (AudioSource obj_audio in arr_obj_audio) {
				obj_audio.Stop ();
			}
		}
	}

	public void ft_audio_handle(AudioSource obj_audio)
	{
		if (obj_audio.isPlaying)
		{
			obj_audio.Stop();
			obj_user_interface.GetComponent<AudioSource>().PlayDelayed(1.5f);
		}
		else
		{
			ft_audio_stop_all();
			obj_audio.Play();
		}
	}
}