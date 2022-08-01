using System;
using UnityEngine;

[Serializable]
public class Item
{
    [Tooltip("The sprite the item should use to display itself")]
    public Sprite itemSprite;

    [Tooltip("The name of the item (!MUST BE UNIQUE!)")]
    public string itemName;

    [Tooltip("The effect of the item. Please see the documentation to know the formatting")]
    [TextArea(5, 10)]
    public string effect;

    /*
     * Effects are read and converted into a list of actions to take when a certain event occurs
     *
     *
     */
}