using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posterBehavior : MonoBehaviour {
    TGCConnectionController controller;
    public GameObject[] children;
    private float recordedAttention = 0;
    private bool valuesUpdated = false;

    void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller.UpdateAttentionEvent += OnUpdateAttention;
    }
	
	// Update is called once per frame
	void Update () {
        if (valuesUpdated)
        {
            foreach (GameObject child in children)
            {
                Color color = child.GetComponent<Renderer>().material.color;
                color.a = recordedAttention;
                gameObject.tag = (recordedAttention >= 0.5f) ? "Poster" : "Untagged";
            }
           
            valuesUpdated = false;
        }
    }

    void OnUpdateAttention(int value)
    {
        // value is 0 to 100, but alpha is 0.0 thru 1.0
        recordedAttention = value / 100.0f;
        valuesUpdated = true;
    }
}
