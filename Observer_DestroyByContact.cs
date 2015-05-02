using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IScoreNotifier
{
	int getScore();
	void setScore(int score);
	void attach(IScoreObserver obj);
	void detach(IScoreObserver obj);
	void notifyObservers();
}

public class ScoreNotifier : MonoBehaviour, IScoreNotifier
{
	//	public List<ScoreObserver> scoreObservers = new List<ScoreObserver>();
	public IScoreObserver scoreObserver;
	public int scoreValue;
	
	public int getScore()
	{
		return scoreValue;
	}
	
	public void setScore(int score)
	{
		scoreValue = score;
	}
	
	public void attach(IScoreObserver obj)
	{
		//		scoreObservers.Add(obj);
		scoreObserver = obj;
	}
	
	public void detach(IScoreObserver obj)
	{
		//		scoreObservers.Remove(obj);
	}
	
	public void notifyObservers()
	{
		scoreObserver.updateScore (this);
		//		foreach(ScoreObserver obj in scoreObservers)
		//		{
		//			obj.updateScore(this);
		//		}
	}
}

public class Done_DestroyByContact : ScoreNotifier
{
	public GameObject explosion;
	public GameObject playerExplosion;
	private Done_GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
			this.attach(gameController);
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		//		gameController.AddScore(scoreValue);
		this.notifyObservers();
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
	
	
}