using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerResultImpl : MonoBehaviour {

	// Use this for initialization

	private List<Player> PlayerList = new List<Player>();
	public void addUser(string name)
	{
		Player P = new Player();
		P.setName(name);
		PlayerList.Add (P);
	}

	public PlayerIteratorImpl createIterator()
	{
		PlayerIteratorImpl playerIterator1 = new PlayerIteratorImpl (PlayerList);
		return playerIterator1;
	}

}
