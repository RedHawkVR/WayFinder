using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour
{

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;

	private bool oculus;

	// Swipe
	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	public ObjectMenuManager objectMenuManager;

	public bool isOtherController = false;

	void Start()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		oculus = (UnityEngine.XR.XRDevice.model.Contains("Oculus")) ? true : false;
	}

	void Update()
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
		if (!isOtherController)
		{
			if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
			{
				touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			}
			if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
			{

				touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
				if (oculus)
				{
					swipeSum = touchCurrent;
				}
				else
				{
					distance = touchCurrent - touchLast; // how much did the finger move this frame?
					touchLast = touchCurrent; // cache current
					swipeSum += distance; // add the difference
				}
				if (!hasSwipedRight)
				{
					if (swipeSum > 0.5f)
					{
						swipeSum = 0;
						SwipeRight();
						hasSwipedRight = true;
						hasSwipedLeft = false;
					}
				}
				if (!hasSwipedLeft)
				{
					if (swipeSum < -0.5f)
					{
						swipeSum = 0;
						SwipeLeft();
						hasSwipedRight = false;
						hasSwipedLeft = true;
					}
				}
			}
			if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
			{
				swipeSum = 0;
				touchCurrent = 0;
				touchLast = 0;
				hasSwipedLeft = false;
				hasSwipedRight = false;
			}
			if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
			{
				SpawnObject();
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//triggered when touching every physics object, even walls
		if (other.gameObject.CompareTag("grabbable"))
		{
			if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)
				|| device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
			{
				GrabObject(other);
			}
			else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)
				|| device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
			{
				ThrowObject(other);
			}
		}
	}

	void GrabObject(Collider coli)
	{
		//When item grabbed -> 
		//make controller parent, turn off physics, vibrate
		coli.transform.SetParent(gameObject.transform);
		if(coli.gameObject.name == "pseudoSword")
		{
			coli.transform.SetPositionAndRotation(coli.transform.position, new Quaternion(-15.0f, 0, 0, Quaternion.identity.w));
		}
		coli.GetComponent<Rigidbody>().isKinematic = true;
		coli.GetComponent<Rigidbody>().useGravity = false;
		device.TriggerHapticPulse(2000);
		Debug.Log("You are touching down the trigger of an object");
	}

	/*
	void PlaceObject(Collider coli)
	{
		//When item released -> 
		//unparent controller
		coli.transform.SetParent(null);
		Debug.Log("You have released the trigger");
	}
	*/

	void ThrowObject(Collider coli)
	{
		//When item released -> 
		//unparent controller, turn on physics, set velocity based on controller movement
		coli.transform.SetParent(null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
		rigidBody.useGravity = true;
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
		Debug.Log("You have released the trigger");
	}

	void SwipeRight()
	{
		objectMenuManager.MenuRight();
		Debug.Log("SwipeRight");
	}

	void SwipeLeft()
	{
		objectMenuManager.MenuLeft();
		Debug.Log("SwipeLeft");
	}

	void SpawnObject()
	{
		objectMenuManager.SpawnCurrentObject();
	}
}
