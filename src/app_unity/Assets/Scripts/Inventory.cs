using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Inventory : MonoBehaviour
{
	public GameObject obj_user_interface;

	void Start()
	{
		obj_user_interface = GameObject.FindWithTag ("UserInterface");
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
			obj_user_interface.GetComponent<Audio>().ft_audio_handle(obj_audio);
			break;
		}
	}
}