using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javelin : MonoBehaviour {

	public GameObject particleObject;
	private GameObject parentObject;
	public GameObject player;

	// Use this for initialization
	void Start () {
		particleObject.SetActive(false);
		parentObject = this.transform.parent.gameObject;
	}

	public void ToggleParticles()
	{
		if (parentObject != null)
		{
			if (parentObject == player)
			{
				particleObject.SetActive(true);
				return;
			}
		}
		particleObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("target"))
		{
			TeleportPadScript.IsActive = true;
		}
	}
}
