using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject deathPanel;
	[SerializeField] GameObject GameUI;
	public GameObject firstDeathMenuButton; 

	public IEnumerator ShowDeathUiAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);  
		ShowDeathUi();
	}
	
	public void ShowDeathUi()
	{
		deathPanel.SetActive(true);
		GameUI.SetActive(false);
		EventSystem.current.SetSelectedGameObject(firstDeathMenuButton);
	}
}
