using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javelin : MonoBehaviour {

	private Rigidbody javelinRigidbody;
	private Vector3 startPos;
	private Quaternion startRot;
	public float minBoundary = -13.0f, maxBoundary = 13.0f;

	// Use this for initialization
	void Start () {
		javelinRigidbody = gameObject.GetComponent<Rigidbody>();
		startPos = transform.position;
		startRot = transform.rotation;
	}

	private void LateUpdate()
	{
		if(transform.position.x > maxBoundary || transform.position.x < minBoundary ||
			transform.position.z > maxBoundary || transform.position.z < minBoundary)
		{
			ResetObject();
		}
	}

	private void ResetObject()
	{
		javelinRigidbody.velocity = new Vector3(0, 0, 0);
		javelinRigidbody.useGravity = false;
		javelinRigidbody.isKinematic = true;
		transform.position = startPos;
		transform.rotation = startRot;
	}

}
