using UnityEngine;

public abstract class BoomObserver: MonoBehaviour, IBoomObserver
{
	public abstract void observerUpdate ();
}