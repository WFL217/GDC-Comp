using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Player Transform (Position / Scale)
	private Transform Player;

	//Speed of Player
	private int Speed;

	//Player GameObject Size (Remember to Divide the Number by 2)
	public static float pSize = .5f;

	private float yBoundry = ((58 + pSize) / 2);
	private float xBoundry = ((40 + pSize) / 2);

	// Update is called once per frame
	void Update ()
	{
		PlayersPosition ();

		Movement();

	}

	void Movement()
	{
		Speed = 35;
		if (Input.GetKey(KeyCode.RightShift)) {
			Speed = 15;
			if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) 
			{
				transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);	
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) 
			{
				transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) 
			{
				transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
			}
			else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey(KeyCode.W) && Player.position.y < yBoundry)
			{
				transform.Translate(new Vector3(0, Speed, 0) * Time.deltaTime);
			}
			else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey(KeyCode.S) && Player.position.y > -yBoundry)
			{
				transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S))
			{
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} 
			else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) 
			{
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Player.position.y < yBoundry && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Player.position.y < yBoundry && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Player.position.y > -yBoundry && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Player.position.y > -yBoundry && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, -Speed, 0) * Time.deltaTime);
			}else if (Input.GetKey(KeyCode.W) && Player.position.y < yBoundry)
			{
				transform.Translate(new Vector3(0, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Player.position.y > -yBoundry)
			{
				transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.A) && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.D) && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
			}
		} 
		else 
		{
			if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) 
			{
				transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);	
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) 
			{
				transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) 
			{
				transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
			}
			else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey(KeyCode.W) && Player.position.y < yBoundry)
			{
				transform.Translate(new Vector3(0, Speed, 0) * Time.deltaTime);
			}
			else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey(KeyCode.S) && Player.position.y > -yBoundry)
			{
				transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S))
			{
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} 
			else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) 
			{
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Player.position.y < yBoundry && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Player.position.y < yBoundry && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Player.position.y > -yBoundry && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Player.position.y > -yBoundry && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, -Speed, 0) * Time.deltaTime);
			}else if (Input.GetKey(KeyCode.W) && Player.position.y < yBoundry)
			{
				transform.Translate(new Vector3(0, Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.S) && Player.position.y > -yBoundry)
			{
				transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.A) && Player.position.x > -xBoundry)
			{
				transform.Translate(new Vector3(-Speed, 0, 0) * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.D) && Player.position.x < xBoundry)
			{
				transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
			}
		}
	}

	void PlayersPosition()
	{
		Player = transform;
	}
}