using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject enemies;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)){
			Application.LoadLevel ("Title screen");
		}
		if (enemies == null) {
			Application.LoadLevel ("Title screen");
		}
	}
}
