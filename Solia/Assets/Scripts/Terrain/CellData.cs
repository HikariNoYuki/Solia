using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CellData", menuName = "ScriptableObjects/CellData")]
public class CellData : ScriptableObject
{
    [Serializable]
    public class Cell
    {
        public GameObject cell;
        public int weight;
        public int difficulty;
        
    }

    [SerializeField] public List<Cell> CellList;

    //choix au haard
    //chosse cell en fonction de la distance au rentre, return cell a instancier
    //

}
