//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class PlayerInteractUI : MonoBehaviour
//{
//	[SerializeField] private GameObject interactable;
//	[SerializeField] private PlayerInteract playerInteract;
//	[SerializeField] private TextMeshProUGUI interactText;
	
	
//	// Update is called every frame, if the MonoBehaviour is enabled.
//	protected void Update()
//	{
//		if (playerInteract.GetInteractableObject() != null)
//		{
//			Show(playerInteract.GetInteractableObject());
//		}
//		else
//		{
//			Hide();
//		}
//	}
	
//	private void Show(NPCInteractable npcInteractable)
//	{
//		interactable.SetActive(true);
//		interactText.text = npcInteractable.GetInteractText();
//	}
	
//	private void Hide()
//	{
//		interactable.SetActive(false);
//	}
//}
