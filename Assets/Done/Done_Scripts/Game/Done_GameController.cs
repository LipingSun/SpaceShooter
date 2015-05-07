using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public GameObject[] backgrounds;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float time;
	public static int finalScore;
	public GameObject bomb;
	public int level;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	private int score;
	private AudioSource backgroundMusic;
	private GameObject background;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();

		background = Instantiate (backgrounds[0], backgrounds[0].transform.position, backgrounds[0].transform.rotation) as GameObject;

		switch (level) {
		case 1:
			GetComponents<AudioSource>()[0].Play();
//			background1.renderer.enabled = false;
//			background2.renderer.enabled = true;
//			background3.renderer.enabled = false;
			break;
		case 2:
			GetComponents<AudioSource>()[1].Play();
			break;
		case 3:
			GetComponents<AudioSource>()[2].Play();
			break;
		}
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnBonus ());
	}
	
	void Update ()
	{
		if (score >= 100 && level == 1) 
		{
			level = 2;
			Destroy(background);
			background = Instantiate (backgrounds[1], backgrounds[1].transform.position, backgrounds[1].transform.rotation) as GameObject;
			GetComponents<AudioSource>()[0].Stop();
			GetComponents<AudioSource>()[1].Play();
		}
		if (score >= 300 && level == 2) 
		{
			level = 3;
			Destroy(background);
			background = Instantiate (backgrounds[2], backgrounds[2].transform.position, backgrounds[2].transform.rotation) as GameObject;
			GetComponents<AudioSource>()[1].Stop();
			GetComponents<AudioSource>()[2].Play();
		}

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
			if (Input.GetKeyDown (KeyCode.B)) {
				Application.LoadLevel ("StartMenu");
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Done_Mover hazardMover = hazard.GetComponent<Done_Mover> ();
				switch (level) {
				case 1:
					hazardMover.speed = -5;
					break;
				case 2:
					hazardMover.speed = -7;
					break;
				case 3:
					hazardMover.speed = -10;
					break;
				}
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver) {
//				restartText.text = "Press 'R' for Restart";
				restartText.text = "Press 'B' for Return";
				restart = true;
				break;
			}
		}
	}

	IEnumerator SpawnBonus ()
	{
		while (true) {
			yield return new WaitForSeconds (time);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (bomb, spawnPosition, spawnRotation);
			if (gameOver) {
//				restartText.text = "Press 'R' for Restart";
				restartText.text = "Press 'B' for Return";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		finalScore = score;
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
	
}
