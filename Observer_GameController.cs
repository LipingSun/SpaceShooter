using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IScoreObserver
{
	void updateScore (IScoreNotifier obj);
}


public class Done_GameController : MonoBehaviour, IScoreObserver
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	public static int finalScore;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScoreText ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void updateScore(IScoreNotifier obj)
	{
		this.score += obj.getScore();
		UpdateScoreText ();
	}
	
	//	public void AddScore (int newScoreValue)
	//	{
	//		score += newScoreValue;
	//		UpdateScoreText ();
	//	}
	
	void UpdateScoreText ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		finalScore = score;
		gameOverText.text = "Game Over!";
		gameOver = true;
		Application.LoadLevel (1);
	}
}