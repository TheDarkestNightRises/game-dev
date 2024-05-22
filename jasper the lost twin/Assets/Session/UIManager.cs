using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject deathPanel;
	[SerializeField] GameObject timer;
	[SerializeField] GameObject hpBar;

	public void ShowDeathUi()
	{
		deathPanel.SetActive(true);
		timer.SetActive(false);
		hpBar.SetActive(false);
	}
}
