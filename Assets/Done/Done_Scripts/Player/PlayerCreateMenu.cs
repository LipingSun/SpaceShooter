using UnityEngine;
using System.Collections;

public class PlayerCreateMenu : MonoBehaviour {

	// Use this for initialization

	private string playerName = "";
	PlayerResultImpl PlayerWorld = new PlayerResultImpl ();
	private string showname = "";
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
		PlayerPrefs.SetInt ("CurrentScore", getscore);
		if (PlayerPrefs.GetInt ("HighestScore") < getscore) 
		{
			PlayerPrefs.SetString("HighestUser", PlayerPrefs.GetString("CurrentUser")); 
			PlayerPrefs.SetString("HighestScore", PlayerPrefs.GetString("CurrentScore"));
		}
		//getscore = 100;
//		if(!Iterator.isEmpty())
//		{
//			Iterator.lastPlayer ().setScore (getscore);
//		}

	}

	// Update is called once per frame
//	void Update () {
//		PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
//		//getscore = Done_GameController.finalScore;
//		getscore = Done_GameController.finalScore;
//
//		if(!Iterator.isEmpty())
//		{
//			Iterator.lastPlayer ().setScore (getscore);
//		}
//	}



	void OnGUI()
	{

		//playerName = GUI.TextField(new Rect (350, 100, 100, 30), playerName, 25);
		playerName = GUI.TextField(new Rect (Screen.width / 1.8f, Screen.height / 3.8f, Screen.width / 5, Screen.height / 15), playerName, 25);
		GUI.Label(new Rect(Screen.width / 2.8f, Screen.height / 3.8f, Screen.width / 5, Screen.height / 15), "Please Enter Your Name");

		//test
		//GUI.Label(new Rect(400,55, 100, 30), playerName);


		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2.5f, Screen.width / 5, Screen.height / 15), "Start")) {
//			PlayerWorld.addUser(playerName);
			PlayerPrefs.SetString("CurrentUser", playerName);
			Application.LoadLevel("PlayerMenu");

		}

		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.9f, Screen.width / 5, Screen.height / 15), "Show Best Player")) {

			//Load the best score in the memory.
//			string PreviousBestPlayer = PlayerPrefs.GetString("HighestPlayer");
//			int PreviousHighScore = PlayerPrefs.GetInt ("HighestScore");
			bestscore = Done_GameController.finalScore;
//
//			PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
//		
//			while(!Iterator.isDone())
//			{
//
//
//				testscore = Iterator.currentPlayer().getScore();
//				bestPlayer = Iterator.currentPlayer().getName();
//				if(testscore > bestscore)
//				{
//					bestscore = testscore;
//					bestPlayer = Iterator.currentPlayer().getName();
//				}
//
//   			    Iterator.next ();
//
//			}

			showPlayer = "Best Player: Tester";
			showScore = "Best Score: ";
			scoreonscreen = bestscore.ToString();

//			//save the best palyer information to PlayerPrefs
//			PlayerPrefs.SetString("BestPlayer", bestPlayer);
//			PlayerPrefs.SetInt("BestScore", bestscore);

		}

		GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 15), showPlayer);
		GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, Screen.width / 5, Screen.height / 15), showScore);
		GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 15), bestPlayer);
		GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 1.4f, Screen.width / 5, Screen.height / 15), scoreonscreen);

		//GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 4, Screen.width / 5, Screen.height / 15), test1);
		//GUI.Label(new Rect(Screen.width / 2.8f, Screen.height / 4, Screen.width / 5, Screen.height / 15), test2);

	}
	
}
