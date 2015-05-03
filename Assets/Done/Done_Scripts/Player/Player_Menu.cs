using UnityEngine;
using System.Collections;

public class Player_Menu : MonoBehaviour {

	private int score = Done_GameController.finalScore;
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 6, Screen.width / 5, Screen.height / 15), "Level 1")) {
			//Application.LoadLevel("PlayerCreate");
			Application.LoadLevel("Done_Main");
		}
//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 4, Screen.width / 5, Screen.height / 15), "Level 2")) {
//			//Application.LoadLevel(1);
//		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Return")) {
			Application.LoadLevel("PlayerCreateMenu");
		}
	}

}
