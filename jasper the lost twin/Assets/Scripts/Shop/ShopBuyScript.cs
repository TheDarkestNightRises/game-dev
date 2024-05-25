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

	void Start()
	{
		gameSession = GameSession.instance;

		if (gameSession == null)
		{
			Debug.LogError("GameSession not found");
			return;
		}

		UpdateButtonColors();
	}

	void Update()
	{
		UpdateButtonColors();
		HandlePurchaseInput();
	}

	void UpdateButtonColors()
	{
		float currentGold = gameSession.gold;

		int cost1 = GetPriceFromText(priceText1);
		int cost2 = GetPriceFromText(priceText2);
		int cost3 = GetPriceFromText(priceText3);

		UpdateButtonColor(button1, currentGold >= cost1);
		UpdateButtonColor(button2, currentGold >= cost2);
		UpdateButtonColor(button3, currentGold >= cost3);
	}
    
	int GetPriceFromText(TextMeshProUGUI priceText)
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

	void UpdateButtonColor(Button button, bool canAfford)
	{
		ColorBlock colors = button.colors;
		colors.normalColor = canAfford ? Color.green : Color.red;
		button.colors = colors;
	}

	void HandlePurchaseInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			TryPurchase(button1, priceText1);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			TryPurchase(button2, priceText2);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			TryPurchase(button3, priceText3);
		}
	}
	
	void TryPurchase(Button button, TextMeshProUGUI priceText)
	{
		int cost = GetPriceFromText(priceText);
		if (gameSession.gold >= cost)
		{
			SpendGold(cost);
			UpdateButtonColors();
		}
		else
		{
			Debug.Log("Not enough gold to purchase item.");
		}
	}
	
	public void SpendGold(int goldToSpend)
	{
	    gameSession.gold -= goldToSpend;
		ResourceEvents.goldIncreased.Invoke(gameSession.gameObject, gameSession.gold);
	}

}
