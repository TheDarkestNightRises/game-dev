using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI goldText;

	private void Awake()
	{
		goldText = GetComponent<TextMeshProUGUI>();
	}
	
	public void Start()
	{
		SetText(GameSession.instance.gold);
	}
	
	private void OnEnable()
	{
		ResourceEvents.GoldIncreased += OnGoldIncreased;
	}

	private void OnDisable()
	{
		ResourceEvents.GoldIncreased -= OnGoldIncreased;
	}

	private void OnGoldIncreased(GameObject player, float newGold)
	{
		SetText(newGold);
	}
	
	private void SetText(float newGold)
	{
		goldText.text = newGold.ToString();
	}
}
