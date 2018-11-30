using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
	TGCConnectionController controller;

	public float speed = 5.0f;
	public float interval = 5.0f;
	public ParticleSystem childParticleSystem;

	[SerializeField]
	private int recordedAttention = 0;
	[SerializeField]
	private int recordedMeditation = 0;

	private float levitationLevel = 0;
	private Rigidbody rigidBody;
	private Vector3 newLocation;
	private bool locationUpdated;
	private float time = 0;

	void Start()
	{
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		newLocation = this.transform.position;
		locationUpdated = false;
		rigidBody = GetComponent<Rigidbody>();
		childParticleSystem.enableEmission = false;
	}

	void Update()
	{
		time += Time.deltaTime;
		if (locationUpdated && time >= interval)
		{
			if (recordedAttention >= 15 && recordedMeditation >= 15)
			{
				levitationLevel = (recordedMeditation + recordedAttention) / 40.0f;
				rigidBody.useGravity = false;
				childParticleSystem.enableEmission = true;
				User.HasFocus = true;
			}
			else
			{
				levitationLevel = -0.4f;
				rigidBody.useGravity = true;
				childParticleSystem.enableEmission = false;
				User.HasFocus = false;
			}
			newLocation = new Vector3(this.transform.position.x, levitationLevel, this.transform.position.z);
			this.transform.position = Vector3.Lerp(this.transform.position, newLocation, Time.deltaTime * speed);
			locationUpdated = false;
			time = 0;
		}
	}

	void OnUpdateAttention(int value)
	{
		recordedAttention = value;
		locationUpdated = true;
	}

	void OnUpdateMeditation(int value)
	{
		recordedMeditation = value;
		locationUpdated = true;
	}
}
