using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

/*
 * Script that makes starting screen text fade in and out.
 */
public class Start_Text_Fader : MonoBehaviour {

    public CanvasGroup start_Text;
	
	// Update is called once per frame
	void FixedUpdate () {
        float pingpong = Mathf.PingPong(0.3f * Time.time, 0.9f);
        start_Text.alpha = (pingpong);
	}
} 