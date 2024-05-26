using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
	public Leaderboard LoadEntriesFromPref()
	{
		string jsonString = PlayerPrefs.GetString("LeaderboardEntries");
		var highscores = JsonUtility.FromJson<Leaderboard>(jsonString);
		return highscores;
	}
	
	public LeaderboardEntry AddEntry(int score, string name)
	{
		var entry = new LeaderboardEntry { score = score, name = name };
		var board = LoadEntriesFromPref();
		if (board is null) board = new Leaderboard();
		board.highscores.Add(entry);
		SaveEntriesIntoPref(SortEntries(board));
		return entry;
	}
	
	public void SaveEntriesIntoPref(Leaderboard board)
	{
		string json = JsonUtility.ToJson(board);
		PlayerPrefs.SetString("LeaderboardEntries", json);
		PlayerPrefs.Save();
	}
	
	public Leaderboard SortEntries(Leaderboard board)
	{
		var highscoresSorted = board.highscores.OrderBy(h => h.score).ToList();
		board.highscores = highscoresSorted;
		return board;
	}
}


public class Leaderboard 
{
	public List<LeaderboardEntry> highscores = new List<LeaderboardEntry>();
}

[System.Serializable]
public class LeaderboardEntry
{ 
	public int score;
	public string name;
}

