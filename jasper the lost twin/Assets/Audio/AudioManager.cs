using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource musicSource;
	public static AudioManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PlayMusic(AudioClip musicClip)
	{
		musicSource.clip = musicClip;
		musicSource.Play();
	}

	public void StopMusic()
	{
		musicSource.Stop();
	}
}
