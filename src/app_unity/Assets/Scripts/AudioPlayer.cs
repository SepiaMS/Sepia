using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{
	public GameObject obj_audio_mainmusic;

	void Start()
	{
		obj_audio_mainmusic = GameObject.FindWithTag ("Main Music");
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
			obj_audio_mainmusic.GetComponent<AudioSource>().PlayDelayed(1.5f);
		}
		else
		{
			ft_audio_stop_all();
			obj_audio.Play();
		}
	}

	public void ft_audio_set_volume(AudioSource obj_audio, float volume)
	{
		obj_audio.volume = volume;
	}
}