using UnityEngine;
using System.Collections;

public class Done_DestroyByAcquire : MonoBehaviour {

	private Done_PlayerController playerController;

	void Start () {
	
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerControllerObject != null)
		{
			playerController = playerControllerObject.GetComponent <Done_PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}
		if (other.tag == "Player")
		{
			playerController.AddBomb();
			Destroy (this.gameObject);
		}
	}

}
