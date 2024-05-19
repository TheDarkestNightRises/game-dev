using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
	public Slider slider;

	void Start()
	{
		AudioManager audioManager = AudioManager.instance;

		slider.value = PlayerPrefs.GetFloat("VolumeSliderValue", 0.5f);
		slider.onValueChanged.AddListener(delegate { SaveSliderValue(audioManager); });

		audioManager.musicSource.volume = slider.value;
	}

	void SaveSliderValue(AudioManager audioManager)
	{
		PlayerPrefs.SetFloat("VolumeSliderValue", slider.value);
		audioManager.musicSource.volume = slider.value;
	}
}
