using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
	public Slider slider; 

	void Start()
	{
		slider.value = PlayerPrefs.GetFloat("BrightnessSliderValue", 0.5f);
		slider.onValueChanged.AddListener(delegate { SaveSliderValue(); });
	}

	void SaveSliderValue()
	{
		PlayerPrefs.SetFloat("BrightnessSliderValue", slider.value);
	}
}
