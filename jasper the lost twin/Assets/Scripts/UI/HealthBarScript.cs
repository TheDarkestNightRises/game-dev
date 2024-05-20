using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	public TMP_Text healthBarText;
	public Slider healthSlider;
	Damageable playerDamageable;
	public PlayerData playerData;
	
	private void Awake()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
		{
			return;
		}
		playerDamageable = player.GetComponent<Damageable>();
		if (playerDamageable == null)
		{
			Debug.LogError("Player does not have a Damageable component");
		}
	}
    
	void Start()
	{
		if (playerDamageable != null)
		{
			healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
			healthBarText.text = "HP: " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
		}
	}
    
	private void OnEnable()
	{
		if (playerDamageable != null)
		{
			playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
		}
	}
    
	private void OnDisable()
	{
		if (playerDamageable != null)
		{
			playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
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
