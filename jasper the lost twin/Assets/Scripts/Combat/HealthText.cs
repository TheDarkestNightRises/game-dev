using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
	public Vector3 moveSpeed = Vector3.up;
	public float timeToFade = 1f;
	private RectTransform textTransform;
	private TextMeshProUGUI tmp;
	private float timeElapsed;
	private Color startColor;
	
	protected void Awake()
	{
		textTransform = GetComponent<RectTransform>();
		tmp = GetComponent<TextMeshProUGUI>();
		startColor = tmp.color;
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		textTransform.position += moveSpeed * Time.deltaTime;
		
		timeElapsed += Time.deltaTime;
		
		if (timeElapsed < timeToFade)
		{
			float fade = startColor.a * (1 - (timeElapsed / timeToFade));
			tmp.color = new Color(startColor.r, startColor.g, startColor.b, fade);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
