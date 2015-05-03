using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public interface VirtualGameState
{
	void goToUserMenu();
	void goToQuitConf();
	void quitGame();
	void goToReadMe();
	void goToStartMenu();
}

public class GameState : MonoBehaviour, VirtualGameState
{
	VirtualGameManager vg_manager;

	public GameState(VirtualGameManager vgm)
	{vg_manager = vgm;}

	// Provide the default implementation of handling error events
	public virtual void goToStartMenu()
	{
		Console.WriteLine("You cannot go to Start Menu.");
	}
	                                 

	public virtual void goToUserMenu()
	{
		Console.WriteLine("You cannot go to User Menu.");
	}

	public virtual void goToQuitConf()
	{
		Console.WriteLine("You cannot quit game.");
	}

	public virtual void quitGame()
	{
		Console.WriteLine("You cannot quit game.");
	}

	public virtual void goToReadMe()
	{
		Console.WriteLine("You cannot go to Read Me.");
	}
}

public class GameState_goToUserMenu: GameState
{
	public GameState_goToUserMenu (VirtualGameManager v): base(v)
	{
	}

	public override void goToUserMenu()
	{
		Application.LoadLevel (1);
	}
}

public class GameState_goToReadMe : GameState
{
	public GameState_goToReadMe(VirtualGameManager v): base(v)
	{
	}
	
	public override void goToReadMe()
	{
		Application.LoadLevel (2);
	}
}

public class GameState_quitGame : GameState
{
	public GameState_quitGame(VirtualGameManager v): base(v)
	{
	}
	
	public override void quitGame()
	{
		Application.Quit();
	}
}

public class GameState_goToQuitConf : GameState
{
	public GameState_goToQuitConf(VirtualGameManager v): base(v)
	{
	}
	
	public override void goToQuitConf()
	{
		Application.LoadLevel (3);
	}
}

public class GameState_goToStartMenu : GameState
{
	public GameState_goToStartMenu(VirtualGameManager v): base(v)
	{
	}
	
	public override void goToStartMenu()
	{
		Application.LoadLevel (0);
	}
}

public class VirtualGameManager
{
	VirtualGameState start_Menu;
	VirtualGameState user_Menu;
	VirtualGameState read_Me;
	VirtualGameState quit_Conf;
	VirtualGameState quit_Game;
	VirtualGameState current;

	public VirtualGameManager()
	{
		start_Menu = new GameState_goToStartMenu(this);
		user_Menu = new GameState_goToUserMenu(this);
		read_Me = new GameState_goToReadMe(this);
		quit_Conf = new GameState_goToQuitConf(this);
		quit_Game = new GameState_quitGame(this);
		current = start_Menu;
	}

	public void startMenu()
	{
		//Console.WriteLine("Start Menu");
		current.goToStartMenu();
	}

	public void userMenu()
	{
		//Console.WriteLine ("User Menu");
		current.goToUserMenu();
	}

	public void readMe()
	{
		//Console.WriteLine ("Read Me");
		current.goToReadMe ();
	}

	public void quitConf()
	{
		//Console.WriteLine ("Quit Game?");
		current.goToQuitConf ();
	}

	public void quitGame()
	{
		//Console.WriteLine ("Quit Game");
		current.quitGame ();
	}

	public void setState(int nextState)
	{
		switch (nextState) {
		case 1: current = start_Menu; break;
		case 2: current = user_Menu; break;
		case 3: current = read_Me; break;
		case 4: current = quit_Conf; break;
		case 5: current = quit_Game; break;
		}
	}
}