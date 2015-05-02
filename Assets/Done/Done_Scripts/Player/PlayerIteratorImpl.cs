using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public interface Player_Iterator {
	 Player first();
	 Player next();
	 //Player currentPlayer();
	 bool isDone();
	
	
}
public class PlayerIteratorImpl : MonoBehaviour, Player_Iterator {
	private List<Player> PlayerList;
	private int cursor = 0;
	private int max=0;

	public PlayerIteratorImpl(List<Player> p)
	{
		PlayerList = p;
		cursor = 0;
		max = p.Count;
	}

	// Use this for initialization
	public Player first()
	{
		return PlayerList[0];
	}

	public Player next()
	{
		cursor++;
		if (!isDone ())
			return PlayerList[cursor];
		else
			return null;

	}

	public Player currentPlayer()
	{
		if (!isDone () && max!=0)
			return PlayerList[cursor];
		else
			return null;
	}

	public Player lastPlayer()
	{
		if (PlayerList.Count != 0)
			return PlayerList [PlayerList.Count - 1];
		else
			return null;
	}


	public bool isDone()
	{
		if (PlayerList.Count-1 >= cursor)
			return false;
		else
			return true;
	}

	public bool isEmpty()
	{
		if (PlayerList.Count <= 0)
			return true;
		else
			return false;
	}

}
