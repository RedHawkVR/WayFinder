using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVanish : MonoBehaviour {

    //public GameObject Trigger;
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
        if (Candle.triggered && !moved)//checks if the first challenge is cleared and if the first disappearing wall has not moved
        {
            //newposition.y -= 15.0f;
			newposition = new Vector3(transform.position.x, transform.position.y + 15.0f, transform.position.z);
			transform.Translate(newposition);
            //transform.position = newposition;
            moved = true;
			Debug.Log("moved!");
        }
	}

    public void Default()
    {
        transform.position = defposition;
        moved = false;
    }
}
