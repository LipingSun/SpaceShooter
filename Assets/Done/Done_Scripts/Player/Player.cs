using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	private string playerName;
	private int score=0;

	public void setName(string username)
	{
		playerName = username;
	}

	public string getName()
	{
		return playerName;
	}

	public void setScore(int newScore)
	{
		//if (newScore > score) {
			score = newScore;
		//}
	}

	public int getScore()
	{
		return score;
	}
}
