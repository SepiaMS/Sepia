using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Inventory : MonoBehaviour
{
	public GameObject obj_audio_player;

	void Start()
	{
		obj_audio_player = GameObject.FindWithTag ("Audio Player");
	}

	public void ft_inventory_slot_click_handler()
	{
		GameObject obj_inventory_slot = EventSystem.current.currentSelectedGameObject;
		GameObject obj_inventory_item = obj_inventory_slot.transform.GetChild(0).gameObject;
		switch (obj_inventory_item.GetComponent<Item>().type)
		{
		case "Book":
			break;
		case "Audio":
			AudioSource obj_audio = obj_inventory_item.GetComponent<AudioSource>();
			obj_audio_player.GetComponent<AudioPlayer>().ft_audio_handle(obj_audio);
			break;
		}
	}
}