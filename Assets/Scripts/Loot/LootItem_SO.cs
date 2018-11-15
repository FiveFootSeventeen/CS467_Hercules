using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions { HP, GEM, SANITY, WEAPON, BUFF, EMPTY };

[CreateAssetMenu(fileName = "item", menuName = "Item/Loot Pickup", order = 1)]
public class LootItem_SO : ScriptableObject
{
    public string itemName = "Item";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.HP;

    public int itemAmount = 0;
    public int spawnChanceWeight = 0;

    public Sprite itemIcon = null;
    public Rigidbody2D itemSpawnObject = null;
    public Weapon weaponSlotObject = null;

    public bool isEquipped = false;
    public bool isInteractable = false;
    public bool isStorable = false;
    public bool isUnique = false;
    public bool isStackable = false;
    public bool destroyOnUse = false;
}