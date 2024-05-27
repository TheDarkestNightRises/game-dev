using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HealthManagerUI : MonoBehaviour
{
	public GameObject damageText;
	public GameObject healthText;
	public Canvas gameCanvas;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		gameCanvas = FindObjectOfType<Canvas>();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		CharacterEvents.CharacterDamaged += ShowDamage;
		CharacterEvents.CharacterHealed += ShowHeal;
	}
	
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		CharacterEvents.CharacterDamaged -= ShowDamage;
		CharacterEvents.CharacterHealed -= ShowHeal;
	}
	
	public void ShowDamage(GameObject character, float ammount)
	{
		Vector3 spawn = Camera.main.WorldToScreenPoint(character.transform.position);
		
		TMP_Text tmpText = Instantiate(damageText, spawn, Quaternion.identity, gameCanvas.transform)
			.GetComponent<TMP_Text>();
			
		tmpText.text = ammount.ToString();
	}
	
	public void ShowHeal(GameObject character, float ammount)
	{
		Vector3 spawn = Camera.main.WorldToScreenPoint(character.transform.position);
		
		TMP_Text tmpText = Instantiate(healthText, spawn, Quaternion.identity, gameCanvas.transform)
			.GetComponent<TMP_Text>();
			
		tmpText.text = ammount.ToString();

	}
}
