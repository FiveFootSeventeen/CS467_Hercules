using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour {

    public Image btnImg;
    public TextMeshProUGUI sizeTxt;
    public int btnVal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPress()
    {
        if (GameController.control.itemsInventory[btnVal] != "")
        {
            GameMenu.instance.SelectItem(GameController.control.GetItemInfo(GameController.control.itemsInventory[btnVal]));
        }
    }
}
