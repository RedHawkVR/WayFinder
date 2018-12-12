using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsVanish : MonoBehaviour {

    public GameObject Trigger;
    bool moved;
    Vector3 defposition, newposition;
	private CrystalTrigger crystalTrigger;

	// Use this for initialization
	void Start () {
        defposition = transform.position;
        newposition = defposition;
        moved = false;
		crystalTrigger = Trigger.GetComponent<CrystalTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (crystalTrigger.triggered && moved == false)//checks if the wall has moved and if the trigger has gone off
        {
            newposition.y -= 15;
            transform.position = newposition;//moves wall out of the way
            moved = true;
        }
	}

    public void Default()
    {
        transform.position = defposition;
        moved = false;
    }
}
