using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public LootItem_SO itemDefinition;

    public CharacterStats charStats;
    Inventory charInventory;

    GameObject foundStats;

    #region Constructors
    public void ItemPickUp()
    {
        charInventory = Inventory.instance;
    }
    #endregion

    void Start()
    {
        foundStats = GameObject.FindGameObjectWithTag("Player");
        charStats = foundStats.GetComponent<CharacterStats>();
    }

    void StoreItem()
    {
        charInventory.StoreItem(this);
    }

    public void UseItem()
    {
        switch (itemDefinition.itemType)
        {
            case ItemTypeDefinitions.HP:
                charStats.ApplyHealth(itemDefinition.itemAmount);
                Debug.Log(charStats.GetHealth());
                break;
            case ItemTypeDefinitions.SANITY:
                charStats.ApplyMana(itemDefinition.itemAmount);
                break;
            case ItemTypeDefinitions.GEM:
                charStats.GiveWealth(itemDefinition.itemAmount);
                break;
            case ItemTypeDefinitions.WEAPON:
                charStats.ChangeWeapon(this);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (itemDefinition.isStorable)
            {
                StoreItem();
            }
            else
            {
                UseItem();
            }
        }
    }
}
