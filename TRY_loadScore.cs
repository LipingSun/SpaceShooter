using UnityEngine;
using System.Collections;

public class loadScore : MonoBehaviour {
	public GUIText scoreText; 

	// Use this for initialization
	void Start () {
		scoreText.text = "Highest: " + Done_GameController.finalScore;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
