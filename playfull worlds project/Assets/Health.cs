using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int hp;
	// Use this for initialization
	void Start () {
	}
	public void TakeDamage(int damage) {
		hp -= damage;
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
}
