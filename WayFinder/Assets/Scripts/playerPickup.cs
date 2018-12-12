using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RightMedal : MonoBehaviour {
    public Text countText;
    private int count;
    private AudioSource pickupSound;

    void Start () {
        count = 0;
        SetCountText();
        pickupSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Right Medal"))
        {
            other.gameObject.SetActive(false);
            pickupSound.Play(); //plays audio if object is picked up
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Wrong Medal"))
            SceneManager.LoadScene("PuzzleRoom2");
    }

    void SetCountText()
    {
        countText.text = "Medal Count: " + count.ToString();
		if (count == 3)
		{
			//SceneManager.LoadScene("PuzzleRoom3");
			TeleportPadScript.IsActive = true;
		}
    }
}
