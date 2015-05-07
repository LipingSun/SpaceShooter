using UnityEngine;
using System.Collections;

public class PlayerCreateMenu : MonoBehaviour {

	// Use this for initialization

	private string playerName = "";
	private static PlayerResultImpl PlayerWorld = new PlayerResultImpl ();
	//private string showname = "";
	private int getscore;
	private int testscore;
	private string scoreonscreen = "";
	private int bestscore;
	private string bestPlayer = "";
	//PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();

	private string showScore = "";
	private string showPlayer = "";

	void Start () {
		//update the score of the last player
//		DontDestroyOnLoad(gameObject);
		PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
		getscore = Done_GameController.finalScore;
		//getscore = 20;
		if(!Iterator.isEmpty())
		{
			Iterator.lastPlayer ().setScore (getscore);
		}

	}

	void OnGUI()
	{
		playerName = GUI.TextField(new Rect (Screen.width / 1.8f, Screen.height / 3.8f, Screen.width / 5, Screen.height / 15), playerName, 25);
		GUI.Label(new Rect(Screen.width / 2.8f, Screen.height / 3.8f, Screen.width / 5, Screen.height / 15), "Please Enter Your Name");

		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2.5f, Screen.width / 5, Screen.height / 15), "Next")) {
PlayerWorld.addUser(playerName);
			PlayerPrefs.SetString("CurrentUser", playerName);
			Application.LoadLevel("PlayerMenu");
		}

		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.9f, Screen.width / 5, Screen.height / 15), "Show Best Player")) {

			//Load the best score in the memory.
			//string PreviousBestPlayer = PlayerPrefs.GetString("HighestPlayer");
			int bestscore = PlayerPrefs.GetInt ("BestScore");
			bestPlayer = PlayerPrefs.GetString ("BestPlayerName");

//
			PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
		
			while(!Iterator.isDone())
			{


				testscore = Iterator.currentPlayer().getScore();
				if(testscore > bestscore)
				{
					bestscore = testscore;
					bestPlayer = Iterator.currentPlayer().getName();
				}
				else
				{
					bestPlayer = PlayerPrefs.GetString ("BestPlayerName");
				}

   			    Iterator.next ();

			}

			showPlayer = "Best Player: ";
			showScore = "Best Score: ";
			scoreonscreen = bestscore.ToString();
			PlayerPrefs.SetInt("BestScore", bestscore);
			PlayerPrefs.SetString("BestPlayerName", bestPlayer);



		}

		GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 15), showPlayer);
		GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, Screen.width / 5, Screen.height / 15), showScore);
		GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 15), bestPlayer);
		GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 1.4f, Screen.width / 5, Screen.height / 15), scoreonscreen);
	}
	
}
