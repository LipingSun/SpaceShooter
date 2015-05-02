using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : BoomObserver
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	private Done_PlayerController playerController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null)
		{
			playerController = playerObject.GetComponent <Done_PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
		playerController.attach (this);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other != null && (other.tag == "Boundary" || other.tag == "Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other != null && other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		gameController.AddScore(scoreValue);
		if (other != null) 
		{
			Destroy (other.gameObject);
		}
		Destroy (gameObject);
	}

	public override void observerUpdate()
	{
		OnTriggerEnter (null);
	}
}