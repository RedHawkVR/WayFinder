using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEGStuff : MonoBehaviour {


    TGCConnectionController controller;
    [SerializeField]
    private int recordedAttention = 0;

	//[SerializeField]
    //private int recordedMeditation = 0;

	public int attention { get; set; }

    
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller.UpdateAttentionEvent += OnUpdateAttention;
        //controller.UpdateMeditationEvent += OnUpdateMeditation;
        attention = recordedAttention;
    }
	
	// Update is called once per frame
	void Update () {
        attention = recordedAttention;
	}

    void OnUpdateAttention(int value)
    {
        recordedAttention = value;
    }
	/*
    void OnUpdateMeditation(int value)
    {
        recordedMeditation = value;
    }
	*/
}
