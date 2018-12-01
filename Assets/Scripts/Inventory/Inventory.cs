using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static Inventory instance;

    public CharacterStats charStats;
    GameObject foundStats;

    public Image[] barDisplay = new Image[4];
    public GameObject InventoryDisplayHolder;
    public Image[] inventoryDisplay = new Image[30];

    int inventoryItemCap = 20;
    int idCount = 1;
    bool addedItem = true;

    public Dictionary<int, InventoryEntry> itemsInInventory = new Dictionary<int, InventoryEntry>();
    public InventoryEntry itemEntry;
    #endregion

    #region Initializations
    void Start()
    {
        instance = this;
        itemEntry = new InventoryEntry(0, null, null);
        itemsInInventory.Clear();

        inventoryDisplay = InventoryDisplayHolder.GetComponentsInChildren<Image>();

        foundStats = GameObject.FindGameObjectWithTag("Player");
        charStats = foundStats.GetComponent<CharacterStats>();
    }
    #endregion

    void Update()
    {
        #region Bar Keypress
        //Checking for a hotbar key to be pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerItemUse(101);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerItemUse(102);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerItemUse(103);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerItemUse(104);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            DisplayInventory();
        }
        #endregion

        //Check to see if the item has already been added - Prevent duplicate adds for 1 item
        if (!addedItem)
        {
            TryPickUp();
        }
    }

    public void StoreItem(LootItem itemToStore)
    {
        addedItem = false;

        if ((charStats.characterDefinition.currentInventory + itemToStore.itemDefinition.itemAmount) <= charStats.characterDefinition.maxInventory)
        {
            itemEntry.invEntry = itemToStore;
            itemEntry.stackSize = 1;
            itemEntry.barSprite = itemToStore.itemDefinition.itemIcon;
            itemToStore.gameObject.SetActive(false);
        }
    }

    void TryPickUp()
    {
        bool itsInInv = true;

        //Check to see if the item to be stored was properly submitted to the inventory - Continue if Yes otherwise do nothing
        if (itemEntry.invEntry)
        {
            //Check to see if any items exist in the inventory already - if not, add this item
            if (itemsInInventory.Count == 0)
            {
                addedItem = AddItemToInv(addedItem);
            }
            //If items exist in inventory
            else
            {
                //Check to see if the item is stackable - Continue if stackable
                if (itemEntry.invEntry.itemDefinition.isStackable)
                {
                    foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
                    {
                        //Does this item already exist in inventory? - Continue if Yes
                        if (itemEntry.invEntry.itemDefinition == ie.Value.invEntry.itemDefinition)
                        {
                            //Add 1 to stack and destroy the new instance
                            ie.Value.stackSize += 1;
                            AddItemToBar(ie.Value);
                            itsInInv = true;
                            Destroy(itemEntry.invEntry.gameObject);
                            
                            break;
                        }
                        //If item does not exist already in inventory then continue here
                        else
                        {
                            itsInInv = false;
                        }
                    }
                }
                //If Item is not stackable then continue here
                else
                {
                    itsInInv = false;

                    //If no space and item is not stackable - say inventory full
                    if (itemsInInventory.Count == inventoryItemCap)
                    {
                        itemEntry.invEntry.gameObject.SetActive(true);
                        Debug.Log("Inventory is Full");
                    }
                }

                //Check if there is space in inventory - if yes, continue here
                if (!itsInInv)
                {
                    addedItem = AddItemToInv(addedItem);
                    itsInInv = true;
                }
            }
        }
    }

    bool AddItemToInv(bool finishedAdding)
    {
        itemsInInventory.Add(idCount, new InventoryEntry(itemEntry.stackSize, Instantiate(itemEntry.invEntry), itemEntry.barSprite));

        Destroy(itemEntry.invEntry.gameObject);

        FillInventoryDisplay();
        AddItemToBar(itemsInInventory[idCount]);

        idCount = IncreaseID(idCount);

        #region Reset itemEntry
        itemEntry.invEntry = null;
        itemEntry.stackSize = 0;
        itemEntry.barSprite = null;
        #endregion

        finishedAdding = true;

        return finishedAdding;
    }

    int IncreaseID(int currentID)
    {
        int newID = 1;

        for (int itemCount = 1; itemCount <= itemsInInventory.Count; itemCount++)
        {
            if (itemsInInventory.ContainsKey(newID))
            {
                newID += 1;
            }
            else return newID;
        }

        return newID;
    }

    private void AddItemToBar(InventoryEntry item)
    {
        int barCounter = 0;
        bool increaseCount = false;


        foreach (Image images in barDisplay)
        {
            barCounter += 1;

            if (item.barSlot == 0)
            {
                if (images.sprite == null)
                {
                   
                    item.barSlot = barCounter;

                    images.sprite = item.barSprite;
                    increaseCount = true;
                    break;
                }
            }
            else if (item.invEntry.itemDefinition.isStackable)
            {
                increaseCount = true;
            }
        }

        if (increaseCount)
        {
            barDisplay[item.barSlot - 1].GetComponentInChildren<Text>().text = item.stackSize.ToString();
        }

        increaseCount = false;
    }

    void DisplayInventory()
    {
        if (InventoryDisplayHolder.activeSelf == true)
        {
            InventoryDisplayHolder.SetActive(false);
        }
        else
        {
            InventoryDisplayHolder.SetActive(true);
        }
    }

    void FillInventoryDisplay()
    {
        int slotCounter = 9;

        foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
        {
            slotCounter += 1;
            barDisplay[slotCounter].sprite = ie.Value.barSprite;
            ie.Value.inventorySlot = slotCounter - 9;
        }

        while (slotCounter < 29)
        {
            slotCounter++;
            barDisplay[slotCounter].sprite = null;
        }
    }

    public void TriggerItemUse(int itemToUseID)
    {
        bool triggerItem = false;

        foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
        {
            if (itemToUseID > 100)
            {
                itemToUseID -= 100;

                if (ie.Value.barSlot == itemToUseID)
                {
                    triggerItem = true;
                }
            }
            else
            {
                if (ie.Value.inventorySlot == itemToUseID)
                {
                    triggerItem = true;
                }
            }

            if (triggerItem)
            {
                if (ie.Value.stackSize == 1)
                {
                    if (ie.Value.invEntry.itemDefinition.isStackable)
                    {
                        if (ie.Value.barSlot != 0)
                        {
                            barDisplay[ie.Value.barSlot - 1].sprite = null;
                            barDisplay[ie.Value.barSlot - 1].GetComponentInChildren<Text>().text = "0";
                        }

                        ie.Value.invEntry.UseItem();
                        itemsInInventory.Remove(ie.Key);
                        break;
                    }
                    else
                    {
                        ie.Value.invEntry.UseItem();

                        itemsInInventory.Remove(ie.Key);
                        break;                       
                    }
                }
                else
                {
                    ie.Value.invEntry.UseItem();
                    ie.Value.stackSize -= 1;
                    barDisplay[ie.Value.barSlot - 1].GetComponentInChildren<Text>().text = ie.Value.stackSize.ToString();
                    break;
                }
            }
        }

        FillInventoryDisplay();
    }

}