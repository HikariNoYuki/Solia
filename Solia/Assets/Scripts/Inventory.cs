using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [Tooltip("The list of items in this inventory")]
    public List<Tuple<Item,int>> inventory;

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
        foreach (var iTuples in inventory)
        {
            if ((i.name == iTuples.Item1.name) && iTuples.Item2 < 99 )
            {
                iTuples.Item2 += 1;
            }
            else
            {
                iTuples.Item1 = i;
                iTuples.Item2 = 1;
            }
        }
    }
    
    public void supprItem(Item)
    {
        foreach (var iTuples in inventory)
        {
            if ((Item.name == iTuples.Item1.name) && iTuples.Item2 > 0)
            {
                iTuples.Item2 -= 1;
            }
        }
    }

    public void moveItem(Item)
    {
        
    }

    public void fuseItem(Item)
    {
        
    }
}
