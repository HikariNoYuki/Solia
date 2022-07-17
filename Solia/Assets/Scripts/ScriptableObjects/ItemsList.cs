using System;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

[Serializable]
public class ItemCategory
{
    public enum CategoryList
    {
        Weapons,
        Consumables,
        Armors,
        Resources
    }

    public List<Weapon> Weapons;
    public List<Consumable> Consumables;
    public List<Armor> Armors;
    public List<Resource> Resources;

    public Item GetItem(int Id, CategoryList category)
    {
        switch(category)
        {
            case CategoryList.Weapons: return Weapons[Id];
            case CategoryList.Consumables: return Consumables[Id];
            case CategoryList.Resources: return Resources[Id];
            case CategoryList.Armors: return Armors[Id];
            default:
                throw new NotSupportedException("Category not expected : " + category);
        }
    }

    public Item GetItem(ToSearchItem toSearch) => GetItem(toSearch.itemId, toSearch.category);

    public List<Item> GetItems(List<ToSearchItem> toSearch)
    {
        List<Item> items = new List<Item>();
        foreach(ToSearchItem search in toSearch)
        {
            items.Add(GetItem(search.itemId, search.category));
        }
        return items;
    }

    public List<Slot> GetItemsSlots(List<ToSearchItem> toSearch)
    {
        List<Slot> items = new List<Slot>();
        foreach(ToSearchItem search in toSearch)
        {
            items.Add(new Slot(GetItem(search.itemId, search.category), search.quantity));
        }
        return items;
    }
}

//class used to facilitate item searching
[Serializable]
public class ToSearchItem
{
    [Tooltip("The category of the item")]
    public ItemCategory.CategoryList category;

    [Tooltip("The id of the item")]
    public int itemId;

    [Tooltip("the amount of that item")]
    public int quantity = 1;
}

[CreateAssetMenu(fileName = "ItemsListData", menuName = "ScriptableObjects/ItemsListData")]
public class ItemsList : ScriptableObject
{
    public ItemCategory items = new ItemCategory();
}