using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * When "jump" button is pressed, play selected sounds. 
 * After that in next script fade.
 */
public class PressStart : MonoBehaviour {

    public AudioSource press_start;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            press_start.Play();
        }
    }
}
