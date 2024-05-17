using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI timerText;
	[SerializeField] float remainingTime;

	// Update is called once per frame
	void Update()
	{
		if (remainingTime > 0)
		{
			remainingTime -= Time.deltaTime;
		}
		else if (remainingTime < 0)
		{
			remainingTime = 0;
		}

		int minutes = Mathf.FloorToInt(remainingTime / 60);
		int seconds = Mathf.FloorToInt(remainingTime % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

		// Change the color to red when remaining time is less than 10 seconds
		if (remainingTime <= 10f)
		{
			timerText.color = Color.red;
		}
		else
		{
			timerText.color = Color.white;
		}
	}
}
