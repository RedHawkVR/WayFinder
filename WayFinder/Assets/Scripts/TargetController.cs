using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public static int TargetCount { get; set; }
	public int threshold = 1;
	private bool completed = false;

	private void Start()
	{
		TargetCount = 0;
	}

	// Update is called once per frame
	void Update () {
		if(TargetCount >= threshold && !completed)
		{
			TeleportPadScript.IsActive = true;
			completed = true;
		}
	}
}
