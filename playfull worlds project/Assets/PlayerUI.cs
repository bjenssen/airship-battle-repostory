using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public RectTransform healthBar;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		Health health = GetComponent<Health> ();
		int hp = health.hp;
		healthBar.sizeDelta = new Vector2 (hp, healthBar.sizeDelta.y);
	}
}
