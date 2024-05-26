using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderBoardUI : MonoBehaviour
{
	[SerializeField]
	private Transform entryPrefab;
	[SerializeField]
	private Transform leaderboard; 
	private Leaderboard leaderboardEntryList;
	private List<Transform> leaderboardEntryTransformList;
	private LeaderboardManager manager;


	protected void Awake()
	{
		manager = GetComponent<LeaderboardManager>();
		leaderboardEntryList = manager.LoadEntriesFromPref();
		leaderboardEntryTransformList = new List<Transform>();
		AddEntryUI(2, "Damm");
		AddEntryUI(1, "Damm");
		AddEntryUI(3, "Damm");
		AddEntryUI(4, "Damm");

		foreach (var entry in leaderboardEntryList.highscores)
		{
			CreateLeaderboardEntryUI(entry, leaderboard, leaderboardEntryTransformList);
		}
	}
	
	private void CreateLeaderboardEntryUI(LeaderboardEntry entry, Transform container, List<Transform> transformList)
	{
		float templateHeight = 35f;
            
		Transform newEntryUI = Instantiate(entryPrefab, container); 
		var entryRect = newEntryUI.GetComponent<RectTransform>();
		entryRect.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
		newEntryUI.gameObject.SetActive(true);
		int position = transformList.Count + 1;	
		newEntryUI.Find("Position").GetComponent<TextMeshProUGUI>().text = position.ToString();
		newEntryUI.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = entry.name;
		newEntryUI.Find("Score").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
		transformList.Add(newEntryUI);
	}
	
	public void AddEntryUI(int score, string name)
	{
		var entry = manager.AddEntry(score, name);
		CreateLeaderboardEntryUI(entry, leaderboard, leaderboardEntryTransformList);
	}
}
