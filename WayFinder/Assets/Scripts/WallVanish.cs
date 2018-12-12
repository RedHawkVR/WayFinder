using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVanish : MonoBehaviour {

    public GameObject Trigger;
    Vector3 defposition,newposition;
    bool moved;
	// Use this for initialization
	void Start () {
        defposition = transform.position;
        newposition = defposition;
        moved = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Trigger.GetComponent<Candle>().triggered&&moved==false)//checks if the first challenge is cleared and if the first disappearing wall has not moved
        {
            newposition.y -= 15;
            transform.position = newposition;
            moved = true;
        }
	}

    public void Default()
    {
        transform.position = defposition;
        moved = false;
    }
}
