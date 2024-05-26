﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
	[SerializeField]
	public SceneField winCutscene;

	public void ChangeToWinCutscene()
	{
		SceneManager.LoadScene(winCutscene);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(DelayWinCutscene());
		}
	}

	private IEnumerator DelayWinCutscene()
	{
		yield return new WaitForSeconds(0.5f);
		ChangeToWinCutscene();
	}

}