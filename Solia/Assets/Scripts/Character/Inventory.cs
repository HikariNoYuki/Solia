using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public class Slot
    {
        public Item SlotItem;
        public int Number;
    }

    [Tooltip("The list of items in this inventory")]
    [SerializeField] public List<Slot> inventory;

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
        foreach(Slot iSlots in inventory)
        {
            if(( i.itemName == iSlots.SlotItem.itemName ) && iSlots.Number < 99)
            {
                iSlots.Number += 1;
                return;
            }
        }

        Slot toAdd = new Slot();
        toAdd.SlotItem = i;
        toAdd.Number = 1;
        inventory.Add(toAdd);
    } 
    
     public void addItem(Item i, int quantity)
     {
         foreach (var iSlots in inventory)
         {
             if ((i.itemName == iSlots.SlotItem.itemName) && iSlots.Number+quantity < 99 )
             {
                 if ((99 - iSlots.Number) <= quantity)
                 {
                     iSlots.Number += quantity;
                     return;
                 }
                 else
                 {
                     quantity = quantity - (99 - iSlots.Number);
                     iSlots.Number = 99;
                 }
             }
             else
             {
                 Slot toAdd = new Slot();
                 toAdd.SlotItem = i;
                 toAdd.Number = quantity;
                 inventory.Add(toAdd);
             }
         }


     }

    public void supprItem(Item i)
    {
        foreach(Slot iSlots in inventory)
        {
            if(( i.itemName == iSlots.SlotItem.itemName ) && iSlots.Number > 0)
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