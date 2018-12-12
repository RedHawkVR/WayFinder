using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public AudioSource audioSource;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("enemy"))
		{
			audioSource.Play();
		}
		GameObject.Destroy(gameObject, 0.75f);
	}
}
