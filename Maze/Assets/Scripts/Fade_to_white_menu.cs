using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_to_white_menu : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        CanvasGroup fade = GetComponent<CanvasGroup>();
        StartCoroutine(DoFadeIn());
        fade.alpha = 1;
    }

    // Fade
    IEnumerator DoFadeIn()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Fading in.");
        CanvasGroup fade = GetComponent<CanvasGroup>();
        fade.interactable = false;
        fade.alpha = 1;
        while (fade.alpha > 0)
        {
            fade.alpha -= Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
