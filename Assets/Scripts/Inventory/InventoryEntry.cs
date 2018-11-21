using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEntry : MonoBehaviour
{
    public LootItem invEntry;
    public int stackSize;
    public int inventorySlot;
    public int barSlot;
    public Sprite barSprite;

    public InventoryEntry(int stackSize, LootItem invEntry, Sprite barSprite)
    {
        this.invEntry = invEntry;

        this.stackSize = stackSize;
        this.barSlot = 0;
        this.inventorySlot = 0;
        this.barSprite = barSprite;
    }
}
