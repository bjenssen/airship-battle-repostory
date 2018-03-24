using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDamage : MonoBehaviour {

	public int damage;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerStay (Collider Col) {
		Health health = GetComponent<Health> ();

		if (Col.tag == "environment") {
			health.TakeDamage (damage);
		}
		if (Col.tag == "player" || Col.tag == "ship") {
			health.TakeDamage (2*damage);
		}
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
