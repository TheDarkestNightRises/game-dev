using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopBuyScript : MonoBehaviour
{
	public Button button1;
	public Button button2;
	public Button button3;
    
	public TextMeshProUGUI priceText1;
	public TextMeshProUGUI priceText2;
	public TextMeshProUGUI priceText3;

	private GameSession gameSession;
	private PlayerScript playerScript;

	void Start()
	{
		gameSession = GameSession.instance;
		playerScript = FindObjectOfType<PlayerScript>();
		if (gameSession == null)
		{
			Debug.LogError("GameSession instance not found");
			return;
		}

		if (playerScript == null)
		{
			Debug.LogError("PlayerScript instance not found");
			return;
		}

		UpdateButtonColors();
	}

	public void Update()
	{
		UpdateButtonColors();
		HandlePurchaseInput();
	}

	public void UpdateButtonColors()
	{
		float currentGold = gameSession.gold;

		int cost1 = GetPriceFromText(priceText1);
		int cost2 = GetPriceFromText(priceText2);
		int cost3 = GetPriceFromText(priceText3);

		UpdateButtonColor(button1, currentGold >= cost1);
		UpdateButtonColor(button2, currentGold >= cost2);
		UpdateButtonColor(button3, currentGold >= cost3);
	}
    
	public int GetPriceFromText(TextMeshProUGUI priceText)
	{
		if (int.TryParse(priceText.text, out int price))
		{
			return price;
		}
		else
		{
			Debug.LogError("Invalid price text: " + priceText.text);
			return int.MaxValue;
		}
	}

	public void UpdateButtonColor(Button button, bool canAfford)
	{
		ColorBlock colors = button.colors;
		colors.normalColor = canAfford ? Color.green : Color.red;
		button.colors = colors;
	}

	public void HandlePurchaseInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (TryPurchase(button1, priceText1))
			{
				IncreasePlayerMaxHealth();
			}
		}
		
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (TryPurchase(button2, priceText2))
			{
				IncreasePlayerHealth();
			}
		}
		
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			TryPurchase(button3, priceText3);
		}
	}
	
	public bool TryPurchase(Button button, TextMeshProUGUI priceText)
	{
		int cost = GetPriceFromText(priceText);
		if (gameSession.gold >= cost)
		{
			SpendGold(cost);
			UpdateButtonColors();
			return true;
		}
		else
		{
			Debug.Log("Not enough gold to purchase item.");
			return false;
		}
	}
	
	public void SpendGold(int goldToSpend)
	{
	    gameSession.gold -= goldToSpend;
		ResourceEvents.goldIncreased.Invoke(gameSession.gameObject, gameSession.gold);
	}
	
	public void IncreasePlayerHealth()
	{
		int healthRestore = GetPriceFromText(priceText2); 
		playerScript.Heal(healthRestore);
	}
	
	public void IncreasePlayerMaxHealth()
	{
		playerScript.playerData.maxHealth += 50;
		CharacterEvents.OnHealthChanged?.Invoke(playerScript.CurrentHealth, playerScript.playerData.maxHealth);
	}

}
