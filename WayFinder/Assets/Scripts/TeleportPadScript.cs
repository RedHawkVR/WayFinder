using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPadScript : MonoBehaviour {

	public Material activeMaterial;
	public GameObject particleObject;
	public GameObject player;
	public string nextScene;
	public float buffer = 1.5f;

	// puzzle 1 stuff
    public GameObject CorrectTrigger;//how to activate the portal
    public GameObject FalseTrigger1, FalseTrigger2;//traps that reset the level
    public GameObject ObjectControl;
	public bool isPuzzle1 = false;

	private MeshRenderer meshRenderer;
	private bool hasChanged = false;
	private float x, z;

	public static bool IsActive { get; set; } // set this to true whenever a puzzle is completed

	public bool forceActive = false; // for scenes without puzzles to be done

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
				LevelComplete();
			}
			if((Mathf.Abs(player.transform.position.x - x) <= buffer) && 
				(Mathf.Abs(player.transform.position.z - z) <= buffer)){
				NextLevel();
			}
		}
        else if(isPuzzle1)
        {
            if (CorrectTrigger.GetComponent<CrystalTrigger>().triggered)
                IsActive = true;
            if(FalseTrigger1.GetComponent<CrystalTrigger>().triggered||FalseTrigger2.GetComponent<CrystalTrigger>().triggered)
            {
                ObjectControl.GetComponent<ObjectController>().Default();
            }
        }
        
	}

	public void LevelComplete()
	{
		meshRenderer.material = activeMaterial;
		particleObject.SetActive(true);
		hasChanged = true;
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
