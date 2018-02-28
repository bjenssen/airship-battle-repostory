using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {

	public float distance;
	public Transform player;

	float pitch;
	float yaw;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void LateUpdate () {
		pitch -= Input.GetAxis ("Mouse Y"); 
		yaw += Input.GetAxis ("Mouse X");

		transform.eulerAngles = new Vector3 (pitch, yaw);
		transform.position = new Vector3(player.position.x, player.position.y+5.0f, player.position.z) - (transform.forward * distance);
	}
}
