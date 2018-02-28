using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float maxSpeed;
	public float maxRotSpeed;
	public float acceleration;
	public float rotAcceleration;
	public float reload;
	public GameObject bullet;
	public Camera mainCamera;
	private Vector3 velocity;
	private float rotSpeed;
	private float friction = 0.99f;
	private float reloading = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (reloading > 0) {
			reloading -= 1;
		}

		if (Input.GetMouseButton (0) && reloading == 0) {
			reloading = reload;
			GameObject bulletInstance; 
			bulletInstance = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), mainCamera.transform.rotation) as GameObject;
			bulletInstance.transform.eulerAngles = new Vector3 (mainCamera.transform.eulerAngles.x - 20, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);
		}

		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		if(Input.GetKey (KeyCode.Space)) {
			input.y = 0.5f;
		}

		if(Input.GetKey (KeyCode.LeftShift)) 
		{
	  		input.y = -0.5f;
		}
		if (velocity.x < maxSpeed) {
			velocity.x += input.x * acceleration * Time.deltaTime;
		}
		if (velocity.y < maxSpeed) {
			velocity.y += input.y * acceleration * Time.deltaTime;
		}
		if (velocity.z < maxSpeed*2.0f) {
			velocity.z += input.z * acceleration * Time.deltaTime;
		}
		velocity = velocity * friction;

		float rot = 0;

		if (Input.GetKey (KeyCode.Q)) 
		{
			rot = -1;
		} 
		if(Input.GetKey (KeyCode.E)) 
		{
			rot = 1;
		}
		if (rotSpeed < maxRotSpeed) {
			rotSpeed += rot * rotAcceleration * Time.deltaTime;
		}
		rotSpeed = rotSpeed * friction * friction;
		
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + (Time.deltaTime * rotSpeed), transform.eulerAngles.z);

		input =	input.normalized;

		transform.Translate (velocity * Time.deltaTime);
	}
}


