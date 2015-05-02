public interface IBoomSubject
{
	void attach(IBoomObserver obj);
	void detach(IBoomObserver obj);
	void notifyObservers();
}
