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

    public void Use()
    {
        CharacterStats character = CharacterStats.instance;
        if (isItem)
        {
            if (affectHP)
            {
                character.ApplyHealth(amountToChange);
                if (character.GetMaxHealth() < character.GetCurrentHealth())
                {
                    character.characterDefinition.currentHealth = character.characterDefinition.maxHealth;
                }
            }
            if (affectSanity)
            {
                character.ApplySanity(amountToChange);
                if (character.GetMaxSanity() < character.GetCurrentSanity())
                {
                    character.characterDefinition.currentSanity = character.characterDefinition.maxSanity;
                }
            }
            if (affectDMG)
            {
                character.characterDefinition.currentDamage += amountToChange;                
            }

            if (affectGems)
            {
                character.characterDefinition.currentGems += amountToChange;
                GameController.control.gemsCollected += amountToChange;
                Debug.Log("Gems: " + GameController.control.gemsCollected);
            }
        }

    }
}
