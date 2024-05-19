using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
	
	    public Slider slider; 
	    public AudioManager audioManager;

		void Start()
     	{
	     	slider.value = PlayerPrefs.GetFloat("VolumeSliderValue", 0.5f);
			slider.onValueChanged.AddListener(delegate { SaveSliderValue(); });
		}

		void SaveSliderValue()
		{
			PlayerPrefs.SetFloat("VolumeSliderValue", slider.value);
			audioManager.musicSource.volume = slider.value;
		}
}
