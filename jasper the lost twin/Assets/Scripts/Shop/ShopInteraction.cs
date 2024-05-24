using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
	public Canvas shopCanvas; // Assign the Canvas in the Inspector
	private bool playerInRange = false;

	void Start()
	{
		if (shopCanvas == null)
		{
			Debug.LogError("Shop Canvas is not assigned.");
		}
		else
		{
			shopCanvas.gameObject.SetActive(false); // Ensure the shop Canvas is initially inactive
		}
	}

	void Update()
	{
		// Check if the player is in range and presses the "b" key
		if (playerInRange && Input.GetKeyDown(KeyCode.B))
		{
			// Toggle the shop Canvas
			shopCanvas.gameObject.SetActive(!shopCanvas.gameObject.activeSelf);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player entered shop trigger.");
			playerInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player exited shop trigger.");
			playerInRange = false;
			// Optionally close the shop Canvas when the player leaves the range
			shopCanvas.gameObject.SetActive(false);
		}
	}
	
}
