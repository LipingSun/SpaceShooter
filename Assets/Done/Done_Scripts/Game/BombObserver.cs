using UnityEngine;

public abstract class BombObserver: MonoBehaviour, IBombObserver
{
	public abstract void observerUpdate ();
}