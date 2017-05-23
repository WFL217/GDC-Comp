using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
	public GameObject playerPrefab;

	public float radius = 10.0f;

	public float timer = 0.0f;
	public float survivalTimer = 20.0f;

	void Start ()
	{
		playerPrefab = GameObject.FindWithTag ("Player");
	}

	void Update ()
	{
		timer += Time.deltaTime;
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			if (timer <= survivalTimer) {
				print ("DEAD");
				Destroy (collision.gameObject);
			} else {
				print ("LIVED");
				timer = 0;
			}
			PlayerMovement player = playerPrefab.GetComponent<PlayerMovement> ();
			player.dimensionShift (true, player.isShifted, player.passTags);
			Collider[] colliders = Physics.OverlapSphere (collision.gameObject.transform.position, radius);
			foreach (Collider col in colliders) {
				if (col.tag == "Enemy" || col.tag == "EnemyProjectile") {
					Destroy (col.gameObject);
				}
			}
		} else if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "EnemyProjectile") {
			print ("hello");
			Physics.IgnoreCollision (collision.collider, GetComponent<Collider> ());
		} else if (collision.gameObject.tag == "Enemy") {
			print ("ur dead");
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}
	}
}