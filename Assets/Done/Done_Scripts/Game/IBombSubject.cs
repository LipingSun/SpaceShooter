public interface IBombSubject
{
	void attach(IBombObserver obj);
	void detach(IBombObserver obj);
	void notifyObservers();
}
