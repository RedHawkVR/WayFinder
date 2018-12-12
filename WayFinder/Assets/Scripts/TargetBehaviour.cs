using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

	TGCConnectionController controller;

	private float recordedAttention = 0;
	private bool valuesUpdated = false;
	private bool hasBeenHit = false;

	private readonly float moveSpeed = 10.001f;
	public float moveRange = 3.0f;
	public bool trackX = false; // will otherwise track the z position

	// Use this for initialization
	void Start()
	{
		
		try
		{
			controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
			controller.UpdateAttentionEvent += OnUpdateAttention;
		}
		catch(System.Exception e)
		{
			Debug.Log("Target Error: " + e);
			controller = null;
		}
		//controller.UpdateMeditationEvent += OnUpdateMeditation;
		//transparency = gameObject.GetComponent<Renderer>().material.color;
	}

	// Update is called once per frame
	void Update()
	{
		if (trackX)
		{
			this.transform.position = new Vector3(Mathf.PingPong(Time.time * (moveSpeed-recordedAttention), moveRange),
				transform.position.y, transform.position.z);
		}
		else
		{
			this.transform.position = new Vector3(transform.position.x,
				transform.position.y, Mathf.PingPong(Time.time * (moveSpeed-recordedAttention), moveRange));
		}
	}

	void OnUpdateAttention(int value)
	{
		// value is 0 to 100, but alpha is 0.0 thru 1.0
		//recordedAttention = value / 100.0f;
		recordedAttention = value / 10.0f; // 0 - 10.0f
		valuesUpdated = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("javelin"))
		{
			if (!hasBeenHit)
			{
				TargetController.TargetCount += 1;
				hasBeenHit = true;
				Destroy(gameObject, 0.5f);
			}
		}
	}
}
