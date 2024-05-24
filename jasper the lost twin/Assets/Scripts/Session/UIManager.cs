using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject deathPanel;
	[SerializeField] GameObject GameUI;

	public IEnumerator ShowDeathUiAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);  
		ShowDeathUi();
	}
	
	public void ShowDeathUi()
	{
		deathPanel.SetActive(true);
		GameUI.SetActive(false);
	}
}
