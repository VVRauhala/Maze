using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor.SceneManagement;

/*
 * When game launches, DoFadeIn will fade from white screen to the main start screen.
 */
public class Fade_to_white : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DoFadeIn());
	}

    // Fade
    IEnumerator DoFadeIn()
    {
        Debug.Log("Fading in.");
        CanvasGroup fade = GetComponent<CanvasGroup>();
        fade.interactable = false;
        fade.alpha = 1;
        while (fade.alpha > 0)
        {
            fade.alpha -= Time.deltaTime / 2;
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(DoFadeOut());
        }
    }

    IEnumerator DoFadeOut()
    {
        StopCoroutine(DoFadeIn());
        CanvasGroup fade = GetComponent<CanvasGroup>();
        Debug.Log("Fading out.");
        fade.alpha = 0;
        while (fade.alpha < 1)
        {
            fade.alpha += Time.deltaTime;
            if(fade.alpha == 1)
            {
                LoadLevel("01_main_menu");
            }
            yield return null;
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Loading level " + name);
        EditorSceneManager.LoadScene(name);
    }
}
