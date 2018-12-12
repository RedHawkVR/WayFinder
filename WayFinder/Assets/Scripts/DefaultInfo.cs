using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInfo : MonoBehaviour {

    Vector3 defpostion;
	// Use this for initialization
	void Start () {
        defpostion = transform.position;//sets a default position for the player in case of level reset
	}
	
    public void Default()
    {
        transform.position = defpostion;
    }
}
