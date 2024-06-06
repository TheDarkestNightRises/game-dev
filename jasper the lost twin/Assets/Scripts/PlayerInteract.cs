//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInteract : MonoBehaviour
//{
//	[SerializeField]
//	public float interactRange = 2f;
	
//	protected void Update()
//	{
//		if (Input.GetKeyDown(KeyCode.E))
//		{
//			var array = Physics2D.OverlapCircle(transform.position, interactRange);
//			foreach (Collider2D collder in array)
//			{
//				if (collder.TryGetComponent(out NPCInteractable npcInteractable))
//				{
//					npcInteractable.Interact();
//				}
//			}
//		}
//	}
	
//	public NPCInteractable GetInteractableObject()
//	{
//		var array = Physics2D.OverlapCircle(transform.position, interactRange);
//		foreach (Collider2D collder in array)
//		{
//			if (collder.TryGetComponent(out NPCInteractable npcInteractable))
//			{
//				npcInteractable.Interact();
//			}
//		}
//	}
//}
