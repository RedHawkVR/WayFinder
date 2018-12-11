using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	public SteamVR_TrackedObject trackedObject = null;
	public SteamVR_Controller.Device device = null;

	private float waitTime = 10.0f;
	private float currentTime = 0;

	private void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > waitTime)
		{
			device = SteamVR_Controller.Input((int)trackedObject.index);
			if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
			{
				SteamVR_LoadLevel.Begin("Scene0");
			}
		}
	}
}
