using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombSubject: MonoBehaviour, IBombSubject
{
	private List<IBombObserver> bombObservers = new List<IBombObserver>();

	public void attach(IBombObserver obj)
	{
		bombObservers.Add (obj);
	}
	public void detach(IBombObserver obj)
	{
		bombObservers.Remove(obj);
	}
	public void notifyObservers()
	{
		while (bombObservers.Count > 0) 
		{
			try
			{
				bombObservers[0].observerUpdate();
			} 
			catch (MissingReferenceException e)
			{
				Debug.Log(e);
			}
			this.detach(bombObservers[0]);
		}
	}
}