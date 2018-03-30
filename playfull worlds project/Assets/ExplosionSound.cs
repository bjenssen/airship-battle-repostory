using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour {
	public AudioClip sound;

	void Start () {
		AudioSource source = GetComponent<AudioSource> ();
		source.pitch = Random.Range (0.9f, 1.1f);
		source.PlayOneShot (sound);

	}
}
