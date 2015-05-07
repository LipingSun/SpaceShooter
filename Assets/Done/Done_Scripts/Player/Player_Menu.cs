using UnityEngine;
using System.Collections;

public class Player_Menu : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 16, Screen.width / 5, Screen.height / 15), "Level 1")) {
			Application.LoadLevel("Game_Level_1");
		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 8, Screen.width / 5, Screen.height / 15), "Level 2")) {
			Application.LoadLevel("Game_Level_2");
		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 4, Screen.width / 5, Screen.height / 15), "Level 3")) {
			Application.LoadLevel("Game_Level_3");
		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Return")) {
			Application.LoadLevel("StartMenu");
		}
	}

}
