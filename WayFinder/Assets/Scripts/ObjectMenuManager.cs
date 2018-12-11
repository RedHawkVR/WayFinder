using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

	public List<GameObject> objectList, objectPrefabList;
	public int currentObject = 0, objectLimit = 1;
	private int listCount = 0, size = 0;
	private GameObject[] spawnedObjects;

	void Start(){
		foreach(Transform child in transform){
			objectList.Add(child.gameObject);
		}
		listCount = objectList.Count - 1;
	}

	void Update()
	{
		spawnedObjects = GameObject.FindGameObjectsWithTag("grabbable");
		if (spawnedObjects.Length > objectLimit)
		{
			size = spawnedObjects.Length - objectLimit;
			for (int i = 0; i < size; i++)
			{
				GameObject.DestroyImmediate(spawnedObjects[i]);
			}
		}
	}

	public void MenuLeft(){
		// swiping menu left
		objectList[currentObject].SetActive(false); //deactivate current object
		currentObject--; //increment to next object
		if(currentObject < 0){
			currentObject = listCount;
		}
		objectList[currentObject].SetActive(true); //activate new current object
	}

	public void MenuRight(){
		// swiping menu right
		objectList[currentObject].SetActive(false); //deactivate current object
		currentObject++; //increment to next object
		if(currentObject > listCount){
			currentObject = 0;
		}
		objectList[currentObject].SetActive(true); //activate new current object
	}

	public void SpawnCurrentObject(){
		Instantiate (objectPrefabList [currentObject], 
			objectList [currentObject].transform.position, 
			objectList [currentObject].transform.rotation);
	}
}
