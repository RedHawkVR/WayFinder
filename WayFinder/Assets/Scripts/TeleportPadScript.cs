using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPadScript : MonoBehaviour {

	public Material activeMaterial;
	public GameObject particleObject;
	public GameObject player;
	public string nextScene;
	public float buffer = 1.0f;

	private MeshRenderer meshRenderer;
	private bool hasChanged = false;
	private float x, z;

	public static bool IsActive { get; set; }

	public bool forceActive = false;

	// Use this for initialization
	void Start () {
		IsActive = false;
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
		x = transform.position.x;
		z = transform.position.z;
		if (forceActive) IsActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsActive)
		{
			if (!hasChanged)
			{
				meshRenderer.material = activeMaterial;
				particleObject.SetActive(true);
				hasChanged = true;
			}
			if((Mathf.Abs(player.transform.position.x - x) <= buffer) && 
				(Mathf.Abs(player.transform.position.z - z) <= buffer)){
				NextLevel();
			}
		}
	}

	private void NextLevel()
	{
		try
		{
			SceneManager.LoadScene(nextScene);
		}
		catch
		{
			Debug.Log("Scene: " + nextScene + " was not found.");
		}
	}

}
