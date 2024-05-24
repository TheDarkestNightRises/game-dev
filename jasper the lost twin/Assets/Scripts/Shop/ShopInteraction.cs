using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopInteraction : MonoBehaviour
{
	public Canvas shopCanvas; 
	public Canvas pressButtonCanvas; 

	private bool playerInRange = false;

	void Start()
	{
		if (shopCanvas == null)
		{
			Debug.LogError("Shop Canvas is not assigned.");
		}
		else
		{
			shopCanvas.gameObject.SetActive(false);
		}

		if (pressButtonCanvas != null)
		{
			pressButtonCanvas.gameObject.SetActive(false); 
		}
	}

	void Update()
	{

		if (playerInRange && Input.GetKeyDown(KeyCode.B))
		{
			shopCanvas.gameObject.SetActive(!shopCanvas.gameObject.activeSelf);
			pressButtonCanvas.gameObject.SetActive(shopCanvas.gameObject.activeSelf); 
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = true;
			if (pressButtonCanvas != null)
			{
				pressButtonCanvas.gameObject.SetActive(true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = false;
			if (pressButtonCanvas != null)
			{
				pressButtonCanvas.gameObject.SetActive(false);
			}
			shopCanvas.gameObject.SetActive(false);
		}
	}
	
}
