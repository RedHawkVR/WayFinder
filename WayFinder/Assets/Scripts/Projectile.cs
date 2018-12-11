using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public AudioSource audio;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("enemy"))
		{
			audio.Play();
		}
		GameObject.Destroy(gameObject, 0.75f);
	}
}
