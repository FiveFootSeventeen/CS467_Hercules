using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour {

    public string[] lines;

    private bool activate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activate && Input.GetButtonDown("Dialog") && !DialogManager.instance.dialogBox.activeInHierarchy) //if in trigger box and dialog box not active 
        {
            DialogManager.instance.ShowDialog(lines);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activate = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activate = false;
        }
    }
}
