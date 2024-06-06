using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAmbience : MonoBehaviour
{
	public AudioClip LevelMusic;


	protected void Start()
	{
		AudioManager.instance.PlayMusic(LevelMusic);
	}
	
	protected void OnDestroy()
	{
		AudioManager.instance.StopMusic();
	}
}
