using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneFadeManager : MonoBehaviour
{
	public static SceneFadeManager instance;
	[SerializeField] private Image _fadeOutImage;
	[Range(0.1f, 10f), SerializeField] private float _fadeOutSpeed = 5f;
	[Range(0.1f, 10f), SerializeField] private float _fadeInSpeed = 5f;

	
	[SerializeField]
	private Color fadeOutStartColor;
	public bool isFadingIn { get; set; }
	public bool isFadingOut { get; set; }

	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		fadeOutStartColor.a = 0f;
	}
	
	protected void Update()
	{
		if (isFadingOut)
		{
			if (_fadeOutImage.color.a < 1f)
			{
				fadeOutStartColor.a += Time.deltaTime * _fadeOutSpeed;
				_fadeOutImage.color = fadeOutStartColor;
			}
			else
			{
				isFadingOut = false;
			}
		}
		
		if (isFadingIn)
		{
			if (_fadeOutImage.color.a > 0f)
			{
				fadeOutStartColor.a -= Time.deltaTime * _fadeInSpeed;
				_fadeOutImage.color = fadeOutStartColor;
			}
			else
			{
				isFadingIn = false;
			}
		}
	}
	
	public void StartFadeOut()
	{
		_fadeOutImage.color = fadeOutStartColor;
		isFadingOut = true;
	}
	
	public void StartFadeIn()
	{
		if (_fadeOutImage.color.a >= 1f)
		{
			_fadeOutImage.color = fadeOutStartColor;
			isFadingIn = true;
		}
	}
}
