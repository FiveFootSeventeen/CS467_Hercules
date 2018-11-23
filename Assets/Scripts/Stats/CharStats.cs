using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {


    public string charName;

    public int charlevel = 1;
    public int currentXP;

    public int[] xpToLevel;
    public int maxLevel = 20;

    public int baseXP = 1000;

    public int currentHP;
    public int maxHP = 100;

    public int currentSanity;
    public int maxSanity = 30;

    public int strength;
    public int armor;

    public int weaponPwr;
    public string equippedWeap;

    public int armorPwr;
    public string equippedArmor;

    public Sprite charImg;
	// Use this for initialization
	void Start () {
        xpToLevel = new int[maxLevel];
        xpToLevel[1] = baseXP;

        for (int i = 2; i < xpToLevel.Length; i++)
        {
            xpToLevel[i] = Mathf.FloorToInt(xpToLevel[i - 1] * 1.1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
