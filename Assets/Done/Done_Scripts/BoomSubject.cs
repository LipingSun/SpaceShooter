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
			boomObservers[0].observerUpdate();
			this.detach(boomObservers[0]);
		}
	}
}