using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour {

	public int damage;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter (Collider Col) {
		Health health = Col.GetComponent<Health> ();

		if (health != null) {
			health.TakeDamage (damage);
		}
	}
}
