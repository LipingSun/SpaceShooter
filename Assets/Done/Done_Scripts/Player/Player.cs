using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	private string name;
	private int score=0;

	public void setName(string username)
	{
		name = username;
	}

	public string getName()
	{
		return name;
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
