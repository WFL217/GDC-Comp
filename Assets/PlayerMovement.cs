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

	public GameObject bulletPrefab;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	public Transform bulletSpawn3;
	public Transform bulletSpawn4;

	public float timer = 0.0f;
	private float rateOfFire = 0.05f;
	public bool isShooting = true;

	public bool isShifted = false;

	public string[] passTags = { "Enemy", "EnemyProjectile" };

	public Rigidbody rb;

	// Update is called once per frame
	void Update ()
	{
		isShooting = false;
		PlayersPosition ();
		InputHandler ();
	}

	void InputHandler ()
	{
		Speed = 40;
		if (Input.GetKey (KeyCode.RightShift)) {
			Speed = 15;
			timer -= Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Slash)) {
				dimensionShift (false, isShifted, passTags);
			} else if (Input.GetKey (KeyCode.Comma) && timer <= 0) {
				timer = rateOfFire;
				Fire (true);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);	
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W) && Player.position.y < yBoundry) {
				transform.Translate (new Vector3 (0, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S) && Player.position.y > -yBoundry) {
				transform.Translate (new Vector3 (0, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D) && Player.position.y < yBoundry && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A) && Player.position.y < yBoundry && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.y > -yBoundry && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.y > -yBoundry && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Player.position.y < yBoundry) {
				transform.Translate (new Vector3 (0, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Player.position.y > -yBoundry) {
				transform.Translate (new Vector3 (0, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, 0, 0) * Time.deltaTime);
			}
		} else {
			timer -= Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Slash)) {
				dimensionShift (false, isShifted, passTags);
			} else if (Input.GetKey (KeyCode.Comma) && timer <= 0) {
				timer = rateOfFire;
				Fire (false);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);	
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W) && Player.position.y < yBoundry) {
				transform.Translate (new Vector3 (0, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S) && Player.position.y > -yBoundry) {
				transform.Translate (new Vector3 (0, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {
				transform.Translate (new Vector3 (0, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D) && Player.position.y < yBoundry && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A) && Player.position.y < yBoundry && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && Player.position.y > -yBoundry && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && Player.position.y > -yBoundry && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.W) && Player.position.y < yBoundry) {
				transform.Translate (new Vector3 (0, Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && Player.position.y > -yBoundry) {
				transform.Translate (new Vector3 (0, -Speed, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && Player.position.x > -xBoundry) {
				transform.Translate (new Vector3 (-Speed, 0, 0) * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.D) && Player.position.x < xBoundry) {
				transform.Translate (new Vector3 (Speed, 0, 0) * Time.deltaTime);
			}
		}
	}

	void PlayersPosition ()
	{
		Player = transform;
	}

	void Fire (bool shiftDown)
	{
		bulletSpawn1.position = Player.position;
		bulletSpawn2.position = Player.position;
		bulletSpawn3.position = Player.position;
		bulletSpawn4.position = Player.position;

		GameObject bullet1;
		GameObject bullet2;
		GameObject bullet3;
		GameObject bullet4;

		if (shiftDown) {
			bullet1 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn1.transform.position + (3 * transform.up) + (1 * transform.right),
				new Quaternion ());
			bullet2 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn2.transform.position + (3 * transform.up) + (-1 * transform.right),
				new Quaternion ());
			bullet3 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn3.transform.position + (2 * transform.up) + (1 * transform.right),
				new Quaternion ());
			bullet4 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn4.transform.position + (2 * transform.up) + (-1 * transform.right),
				new Quaternion ());
		} else {
			bullet1 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn1.transform.position + (2 * transform.up) + (5 * transform.right),
				new Quaternion ());
			bullet2 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn2.transform.position + (2 * transform.up) + (-5 * transform.right),
				new Quaternion ());
			bullet3 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn3.transform.position + (2 * transform.up) + (1 * transform.right),
				new Quaternion ());
			bullet4 = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn4.transform.position + (2 * transform.up) + (-1 * transform.right),
				new Quaternion ());
		}
			

		//Physics.IgnoreCollision (bullet1.GetComponent<Collider> (), GetComponent<Collider> ());
		bullet1.GetComponent<Rigidbody> ().velocity = bullet1.transform.up * 50;
		Destroy (bullet1, 0.75f);

		//Physics.IgnoreCollision (bullet2.GetComponent<Collider> (), GetComponent<Collider> ());
		bullet2.GetComponent<Rigidbody> ().velocity = bullet2.transform.up * 50;
		Destroy (bullet2, 0.75f);

		//Physics.IgnoreCollision (bullet3.GetComponent<Collider> (), GetComponent<Collider> ());
		bullet3.GetComponent<Rigidbody> ().velocity = bullet3.transform.up * 50;
		Destroy (bullet3, 0.75f);

		//Physics.IgnoreCollision (bullet4.GetComponent<Collider> (), GetComponent<Collider> ());
		bullet4.GetComponent<Rigidbody> ().velocity = bullet4.transform.up * 50;
		Destroy (bullet4, 0.75f);
	}

	public void dimensionShift (bool hit, bool shifted, string[] tags)
	{
		if (hit) {
			if (isShifted) {
				isShifted = false;
				print ("pleasework");
				for (int i = 0; i < tags.Length; i++) {
					GameObject[] gwt = GameObject.FindGameObjectsWithTag (tags [i]);
					foreach (GameObject g in gwt) {
						g.transform.position = new Vector3 (g.transform.position.x - 1, g.transform.position.y, g.transform.position.z);
						if (g.tag == "EnemyProjectile") {
							rb = g.GetComponent<Rigidbody> ();
							rb.velocity = new Vector3 (0, -40, 0);
						}
					}
				}
			} else {
				isShifted = true;
				print ("pleasework");
				for (int i = 0; i < tags.Length; i++) {
					GameObject[] gwt = GameObject.FindGameObjectsWithTag (tags [i]);
					foreach (GameObject g in gwt) {
						g.transform.position = new Vector3 (g.transform.position.x + 1, g.transform.position.y, g.transform.position.z);
						if (g.tag == "EnemyProjectile") {
							rb = g.GetComponent<Rigidbody> ();
							rb.velocity = new Vector3 (0, -40, 0);
						}
					}
				}
			}
		} else {
			if (isShifted) {
				isShifted = false;
				print ("heyyyy");
				for (int i = 0; i < tags.Length; i++) {
					GameObject[] gwt = GameObject.FindGameObjectsWithTag (tags [i]);
					foreach (GameObject g in gwt) {
						g.transform.position = new Vector3 (g.transform.position.x - 1, g.transform.position.y, g.transform.position.z);
					}		
				}
			} else {
				isShifted = true;
				print ("heyyyy");
				for (int i = 0; i < tags.Length; i++) {
					GameObject[] gwt = GameObject.FindGameObjectsWithTag (tags [i]);
					foreach (GameObject g in gwt) {
						g.transform.position = new Vector3 (g.transform.position.x + 1, g.transform.position.y, g.transform.position.z);
					}		
				}
			}
		}
	}
}