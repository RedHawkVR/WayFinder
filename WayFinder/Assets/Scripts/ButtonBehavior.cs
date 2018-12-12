using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;

	void Start()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	private void Update()
	{
		device = SteamVR_Controller.Input((int)trackedObject.index);
		// trigger pressed down
		if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
		{
			Play();
		}
	}

	public void Play()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
