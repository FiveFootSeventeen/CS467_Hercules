using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text dialogText;
    public Text speakerText;

    public GameObject dialogBox;
    public GameObject speakerBox;

    public string[] dialogLines;

    public int currentLine;

    public static DialogManager instance;
    private bool firstLine;

	// Use this for initialization
	void Start () {

        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonDown("Dialog"))
            {
                
                if (!firstLine)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                       
                        dialogBox.SetActive(false);
                        PlayerController.instance.playerMoving = true;
                    }
                    else
                    {
                        CheckSpeaker();
                        dialogText.text = dialogLines[currentLine];
                    }
                } else
                {
                    firstLine = false;
                }               
         
            }
        }
	}


    public void ShowDialog(string[] lines)
    {
        
        dialogLines = lines;
        currentLine = 0;
        CheckSpeaker();
        dialogText.text = lines[currentLine];
        dialogBox.SetActive(true);

        firstLine = true;
    }

    public void CheckSpeaker()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            speakerText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
