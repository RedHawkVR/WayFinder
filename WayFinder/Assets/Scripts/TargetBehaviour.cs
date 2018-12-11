using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

	TGCConnectionController controller;

	private float recordedAttention = 0;
	//private int recordedMeditation = 0;
	private bool valuesUpdated = false;
	private bool hasBeenHit = false;
	//private Color transparency;
	public GameObject[] children;
	private float timer = 0.0f;

	public float interval = 3.0f;

	// Use this for initialization
	void Start()
	{
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		//controller.UpdateMeditationEvent += OnUpdateMeditation;
		//transparency = gameObject.GetComponent<Renderer>().material.color;
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= interval && !hasBeenHit)
		{
			if (valuesUpdated)
			{
				foreach (GameObject child in children)
				{
					Color color = child.GetComponent<Renderer>().material.color;
					color.a = recordedAttention;
					gameObject.tag = (recordedAttention >= 0.5f) ? "target" : "Untagged";
				}
				/*
				transparency.a = recordedAttention;
				if (transparency.a >= 0.5f)
				{
					this.gameObject.tag = "target";
				}
				else
				{
					this.gameObject.tag = "Untagged";
				}
				*/
				valuesUpdated = false;
			}
		}
	}

	void OnUpdateAttention(int value)
	{
		// value is 0 to 100, but alpha is 0.0 thru 1.0
		recordedAttention = value / 100.0f;
		valuesUpdated = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (gameObject.CompareTag("grabbable"))
		{
			if (!hasBeenHit)
			{
				//transparency.a = 1.0f;
				foreach (GameObject child in children)
				{
					Color color = child.GetComponent<Renderer>().material.color;
					color.a = 1.0f;
				}
				TargetController.TargetCount += 1;
				hasBeenHit = true;
			}
		}
	}
}
