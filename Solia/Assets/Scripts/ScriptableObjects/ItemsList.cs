using System;
using System.Collections.Generic;
using UnityEngine;

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
}

[CreateAssetMenu(fileName = "ItemsListData", menuName = "ScriptableObjects/ItemsListData")]
public class ItemsList : ScriptableObject
{
    public ItemCategory items = new ItemCategory();
}