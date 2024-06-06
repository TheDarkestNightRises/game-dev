using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractBase : MonoBehaviour, IInteractable
{
	public GameObject Player { get; set; }
	public PlayerInputHandler Input { get; set; }
	public bool CanInteract { get; set; }
	
	public void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		Input = Player.GetComponent<PlayerInputHandler>();
	}
	
	public virtual void Interact()
	{
		if (CanInteract)
		{
			if(Input.InteractInput)
			{
				Interact();
			}
		}
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == Player)
		{
			CanInteract = true;
		}
	}
	
	
	// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	protected void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == Player)
		{
			CanInteract = false;
		}
	}
}
