using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	public TMP_Text healthBarText;
	public Slider healthSlider;
	private PlayerScript playerScript;

	private void Awake()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
		{
			Debug.LogError("Player not found");
			return;
		}

		playerScript = player.GetComponent<PlayerScript>();
		if (playerScript == null)
		{
			Debug.LogError("Player does not have PlayerScript ");
			return;
		}
	}

	private void Start()
	{
		if (playerScript != null)
		{
			healthSlider.value = CalculateSliderPercentage(playerScript.CurrentHealth, playerScript.playerData.maxHealth);
			healthBarText.text = "HP: " + playerScript.CurrentHealth + " / " + playerScript.playerData.maxHealth;
		}
	}

	private void OnEnable()
	{
		if (playerScript != null)
		{
			CharacterEvents.OnHealthChanged += OnPlayerHealthChanged;
		}
	}

	private void OnDisable()
	{
		if (playerScript != null)
		{
			CharacterEvents.OnHealthChanged -= OnPlayerHealthChanged;
		}
	}

	private float CalculateSliderPercentage(float currentHealth, float maxHealth)
	{
		return currentHealth / maxHealth;
	}

	private void OnPlayerHealthChanged(float newHealth, float maxHealth)
	{
		healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
		healthBarText.text = "HP: " + newHealth + " / " + maxHealth;
	}
	
}
