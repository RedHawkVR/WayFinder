using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;
	public string SceneName = "StartScene";

	void Start()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	private void Update()
	{
		device = SteamVR_Controller.Input((int)trackedObject.index);
		// trigger pressed down
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)
				|| device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			SteamVR_LoadLevel.Begin(SceneName);
		}
	}

	public void Exit()
	{
		Application.Quit();
	}
}
