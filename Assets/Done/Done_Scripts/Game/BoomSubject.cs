using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoomSubject: MonoBehaviour, IBoomSubject
{
	private List<IBoomObserver> boomObservers = new List<IBoomObserver>();
	public void attach(IBoomObserver obj)
	{
		boomObservers.Add (obj);
	}
	public void detach(IBoomObserver obj)
	{
		boomObservers.Remove(obj);
	}
	public void notifyObservers()
	{
		while (boomObservers.Count > 0) 
		{
			try
			{
				boomObservers[0].observerUpdate();
			} 
			catch (MissingReferenceException e)
			{
				Debug.Log(e);
			}
			this.detach(boomObservers[0]);
		}
	}
}