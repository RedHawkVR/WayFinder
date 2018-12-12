using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEGStuff : MonoBehaviour {


    TGCConnectionController controller;
    [SerializeField]
    private int recordedAttention = 0;

	//[SerializeField]
	//private int recordedMeditation = 0;

	public static int Attention;

    
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller.UpdateAttentionEvent += OnUpdateAttention;
        //controller.UpdateMeditationEvent += OnUpdateMeditation;
        Attention = recordedAttention;
    }
	/*
	// Update is called once per frame
	void Update () {
        attention = recordedAttention;
	}
	*/
    void OnUpdateAttention(int value)
    {
		Attention = value;
    }
	/*
    void OnUpdateMeditation(int value)
    {
        recordedMeditation = value;
    }
	*/
}
