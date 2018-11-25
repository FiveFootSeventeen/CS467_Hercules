using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Effect")]
    public int amountToChange;
    public bool affectHP, affectSanity, affectDMG, affectGems;

    [Header("Weapon/Armor Deatails")]
    public int weapStrength;
    public int weapRange;
    public int armorValue;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
