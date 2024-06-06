using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
	public static SceneTransition instance;
	public Image fadeImage;
	public float fadeDuration = 1.0f;

	private void Awake()
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

	public IEnumerator FadeOut()
	{
		fadeImage.gameObject.SetActive(true);
		float timer = 0f;
		while (timer <= fadeDuration)
		{
			float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
			timer += Time.deltaTime;
			yield return null;
		}
		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
	}

	public IEnumerator FadeIn()
	{
		float timer = 0f;
		while (timer <= fadeDuration)
		{
			float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
			timer += Time.deltaTime;
			yield return null;
		}
		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
		fadeImage.gameObject.SetActive(false);
	}
}
