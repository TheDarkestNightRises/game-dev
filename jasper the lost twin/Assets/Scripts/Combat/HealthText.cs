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
	
	protected void Awake()
	{
		textTransform = GetComponent<RectTransform>();
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		textTransform.position += moveSpeed * Time.deltaTime;
	}
}
