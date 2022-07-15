using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public class Slot
    {
        public Item SlotItem;
        public int Number;
    }
    [Tooltip("The list of items in this inventory")]
    public List<Slot> inventory;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void addItem(Item i)
    {
        foreach (var iSlots in inventory)
        {
            if ((i.itemName == iSlots.SlotItem.itemName) && iSlots.Number < 99 )
            {
                iSlots.Number += 1;
            }
            else
            {
                iSlots.SlotItem = i;
                iSlots.Number = 1;
            }
        }
    }
    
    public void supprItem(Item i)
    {
        foreach (var iSlots in inventory)
        {
            if ((i.itemName == iSlots.SlotItem.itemName) && iSlots.Number > 0)
            {
                iSlots.Number -= 1;
            }
        }
    }

    public void moveItem(Item i)
    {
        
    }

    public void fuseItem(Item i)
    {
        
    }
}