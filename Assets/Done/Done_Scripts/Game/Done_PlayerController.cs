using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : BombSubject
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	public static int bomb;
	public GUIText bombText;

	void Start ()
	{
		bomb = 10;
		UpdateBomb ();
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}

		if(Input.GetKeyUp(KeyCode.LeftAlt) && bomb > 0 && Time.time > nextFire){
			this.notifyObservers();
			nextFire = Time.time+fireRate * 4;
			MinusBomb();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
	
	public void AddBomb ()
	{
		bomb = bomb + 1;
		UpdateBomb ();
	}

	public int GetBomb()
	{
		return bomb;
	}
	
	public void MinusBomb ()
	{
		bomb = bomb - 1;
		UpdateBomb ();
	}
	
	void UpdateBomb ()
	{
		bombText.text = "Bomb: " + bomb;
	}
}
