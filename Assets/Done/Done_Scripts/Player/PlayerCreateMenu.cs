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
	private int bestscore = 0;
	private string bestPlayer = "";
	//PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
	private int n = 0;
	private string showScore = "";
	private string showPlayer = "";

	void Start () {
		//update the score of the last player
		PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
//		getscore = Done_GameController.finalScore;
		getscore = 100;
		if(!Iterator.isEmpty())
		{
			Iterator.lastPlayer ().setScore (getscore);
		}

	}

	// Update is called once per frame
	void Update () {
		/*getscore = 100+n*1;
		PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
		if(!Iterator.isEmpty())
		{
			Iterator.lastPlayer ().setScore (getscore);
		}
		n++;*/
	}



	void OnGUI()
	{
		playerName = GUI.TextField(new Rect (350, 100, 100, 30), playerName, 25);
		GUI.Label(new Rect(250, 100, 100, 30), "User Name");
		//test
		//GUI.Label(new Rect(400,55, 100, 30), playerName);


		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 15), "Start")) {
			PlayerWorld.addUser(playerName);
			Application.LoadLevel("Done_Main");
		}



		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 15), "Show Best Player")) {
			PlayerIteratorImpl Iterator = PlayerWorld.createIterator ();
			//GUI.Label(new Rect(400,70, 100, 30), "showname");
			while(!Iterator.isDone())
			{


				testscore = Iterator.currentPlayer().getScore();
				bestPlayer = Iterator.currentPlayer().getName();
				if(testscore > bestscore)
				{
					bestscore = testscore;
					bestPlayer = Iterator.currentPlayer().getName();
				}

   			    Iterator.next ();

			}

			showPlayer = "Best Player: ";
			showScore = "Best Score: ";
			scoreonscreen = bestscore.ToString();

			//save the best palyer information to PlayerPrefs
			PlayerPrefs.SetString("BestPlayer", bestPlayer);
			PlayerPrefs.SetInt("BestScore", bestscore);
			
		}


		GUI.Label(new Rect(300,270, 100, 30), showPlayer);
		GUI.Label(new Rect(300,300, 100, 30), showScore);
		GUI.Label(new Rect(400,270, 100, 30), bestPlayer);
		GUI.Label(new Rect(400,300, 100, 30), scoreonscreen);




	}






}
