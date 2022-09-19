using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [Serializable]  //class that represent a slot in the inventory (tuple Item - Number)
    public class Slot
    {
        public Item SlotItem;

        [SerializeField]
        private int _number;

        public int Number
        {
            get => _number;
            set
            {
                if(value >= 0)
                {
                    _number = value;
                }
            }
        }

        public Slot(Item slotItem, int number)
        {
            SlotItem = slotItem;
            Number = number;
        }
    }

    [Tooltip("The list of items in this inventory")]
    [SerializeField] public List<Slot> inventory = new List<Slot>();

    [Tooltip("State of the inventory: true = open; false = closed")]
    private bool status = false;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

    }

    //Open or close inventory
    public void TryOpenCloseInventory(InputAction.CallbackContext context)
    {
        if (context.performed && status == false)
        {
            //open inventory
            status = true;
        }
        else if(context.performed && status)
        {
            //close inventory
            status = false;
        }
        
    }
    
    
    //remove from the inventory the slots with 0 quantity
    private void CleanupEmpty() => inventory.RemoveAll(iSlot => iSlot.Number <= 0);

    //add quantity item to the inventory
    public void addItem(Item i, int quantity)
    {
        foreach(Slot iSlots in inventory)
        {
            if(i.itemName == iSlots.SlotItem.itemName)
            {
                if(( 99 - iSlots.Number ) >= quantity)
                {
                    iSlots.Number += quantity;
                    return;
                }
                else
                {
                    quantity -= 99 - iSlots.Number;
                    iSlots.Number = 99;
                }
            }
        }

        //if not in for each, means cannot stack, so need to make a new stack
        Slot toAdd = new Slot(i, quantity);
        inventory.Add(toAdd);
    }

    //Add one item to the inventory
    public void addItem(Item i) => addItem(i, 1);

    //add a slot to the inventory
    public void addItem(Slot slot) => addItem(slot.SlotItem, slot.Number);

    //remove quantity item from the inventory, return if sucessful
    public bool supprItem(Item i, int quantity)
    {
        foreach(Slot iSlots in inventory)
        {
            if(iSlots.SlotItem.itemName == i.itemName)
            {
                if(iSlots.Number >= quantity)
                {
                    iSlots.Number -= quantity;

                    //cleanup before return
                    CleanupEmpty();
                    return true;
                }
                else
                {
                    //slot emptied, remove it from inventory afterward
                    quantity -= iSlots.Number;
                    iSlots.Number = 0;
                }
            }
        }
        //cleanup
        CleanupEmpty();
        return false;
    }

    //remove on item from the inventory, return if sucessful
    public bool supprItem(Item i) => supprItem(i, 1);

    //remove a slot from the inventory, return if successful
    public bool supprItem(Slot slot) => supprItem(slot.SlotItem, slot.Number);

    //return if an item is present with the given quantity
    public bool CheckIfPresent(Item i, int quantity)
    {
        int currentAmount = 0;
        foreach(Slot iSlots in inventory)
        {
            if(iSlots.SlotItem.itemName == i.itemName)
            {
                currentAmount += iSlots.Number;
            }
            if(currentAmount >= quantity)
            {
                return true;
            }
        }
        return false;
    }

    //return if an item is present in the inventory
    public bool CheckIfPresent(Item i) => CheckIfPresent(i, 1);

    //return if a slot is present in the inventory
    public bool CheckIfPresent(Slot slot) => CheckIfPresent(slot.SlotItem, slot.Number);

    //return if a list of slots is present in the inventory (one missing = false)
    public bool CheckIfPresent(List<Slot> itemsList)
    {
        foreach(Slot iSlot in itemsList)
        {
            if(!CheckIfPresent(iSlot))
            {
                return false;
            }
        }
        return true;
    }

    //check if an item exist in enough quantity, and remove it if present
    public bool CheckAndRemove(Item i, int quantity)
    {
        if(CheckIfPresent(i, quantity))
        {
            supprItem(i, quantity);
            return true;
        }
        return false;
    }

    //check if an item exist and remove it if present
    public bool CheckAndRemove(Item i) => CheckAndRemove(i, 1);

    //check if a slot exists and remove it if present
    public bool CheckAndRemove(Slot slot) => CheckAndRemove(slot.SlotItem, slot.Number);

    //check if a lsit of slots exists, and if all of them are present, remove them
    public bool CheckAndRemove(List<Slot> itemsList)
    {
        foreach(Slot iSlot in itemsList)
        {
            if(!CheckIfPresent(iSlot))
            {
                return false;
            }
        }
        foreach(Slot iSlot in itemsList)
        {
            supprItem(iSlot);
        }
        return true;
    }

    public void moveItem(Item i)
    {
    }

    public void fuseItem(Item i)
    {
    }
}