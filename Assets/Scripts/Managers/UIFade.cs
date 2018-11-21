using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {


    public static UIFade instance;
    public Image fadeScreen;
    public float fadeSpeed = 1f;
    private bool fade;
    private bool unfade;

	// Use this for initialization
	void Start () {
        instance = this; //so other scripts can call this one
        DontDestroyOnLoad(gameObject); //keep UI fader alive between scenes
		
	}	

	void Update () {

        if (fade) //fade to black
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                fade = false;
            }
        }

        if (unfade) //unfade from black
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                unfade = false;
            }
        }

    }

    public void Fade()
    {
        fade = true;
        unfade = false;
    }

    public void Unfade()
    {
        fade = false;
        unfade = true;
    }
}
