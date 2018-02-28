using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour {

	public float maxSpeed;
	public float maxRotSpeed;
	public float acceleration;
	public float rotAcceleration;
	public float reload;
	public GameObject bullet;
	public GameObject player;
	private Vector3 velocity;
	private float rotSpeed;
	private float friction = 0.99f;
	private float reloading = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < 200) {

			if (reloading > 0) {
				reloading -= 1;
			}

			float hor = 0;
			float ver = 1;
			Vector3 input = new Vector3 (hor, 0, ver);

			if (player.transform.position.y - transform.position.y > 10) {
				input.y = 0.5f;
			}

			if (player.transform.position.y - transform.position.y < -10) {
				input.y = -0.5f;
			}
			if (velocity.x < maxSpeed) {
				velocity.x += input.x * acceleration * Time.deltaTime;
			}
			if (velocity.y < maxSpeed) {
				velocity.y += input.y * acceleration * Time.deltaTime;
			}
			if (velocity.z < maxSpeed * 2.0f) {
				velocity.z += input.z * acceleration * Time.deltaTime;
			}

			float rot = 0;
			float distance = Vector3.Distance (player.transform.position, transform.position);
			float rotation = Vector3.Angle (transform.forward, transform.position - player.transform.position);
			print (distance);
			print (rotation);

			Vector3 targetDir = player.transform.position - transform.position;
			float angle = Vector3.Angle (targetDir, transform.forward);

			if (Vector3.Distance (player.transform.position, transform.position) <= 50 && Vector3.Distance (player.transform.position, transform.position) >= 20) {
				if (Vector3.Angle (transform.forward, transform.position - player.transform.position) > 0 && Vector3.Angle (transform.forward, transform.position - player.transform.position) < 90) {
					rot = -1;
				} 
				if (Vector3.Angle (transform.forward, transform.position - player.transform.position) < 180 && Vector3.Angle (transform.forward, transform.position - player.transform.position) > 90) {
					rot = 1;
				} 
				if (distance < 50 && distance > 20 && reloading == 0) {
					reloading = reload;
					GameObject bulletInstance; 
					bulletInstance = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
					bulletInstance.transform.LookAt (player.transform.position);
				}

			}

			if (Vector3.Distance (player.transform.position, transform.position) > 50 || Vector3.Distance (player.transform.position, transform.position) < 20) {
				if (rotSpeed < maxRotSpeed) {
					rotSpeed += rotAcceleration * Time.deltaTime;
				}
				Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, rotSpeed / 1000, 0);
				Debug.DrawRay (transform.position, newDir, Color.red);
				transform.rotation = Quaternion.LookRotation (newDir);
			}

			input =	input.normalized;
		}

		rotSpeed = rotSpeed * friction;
		velocity = velocity * friction;
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + (Time.deltaTime * rotSpeed), transform.eulerAngles.z);
		transform.Translate (velocity * Time.deltaTime);
	}
}
