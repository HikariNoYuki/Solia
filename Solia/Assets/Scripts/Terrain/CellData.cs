using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public GameObject CellChoice(int dist)
    {
        int summedWeights = 0;
        foreach (Cell c in CellList) //calcul of the sum of all cell's weights taking the difficulty, weight and distance to center into account
        {
            if (dist <= c.difficulty)
            {
                summedWeights += c.weight * (dist / c.difficulty) * 10;
            }
            else
            {
                summedWeights += c.weight * (c.difficulty / dist) * 10;
            }
        }

        float gene = Random.Range(0f, 1f) * CellList.Count * summedWeights; //generation calcul

        foreach (Cell c in CellList)
        {
            gene -= c.weight;
            if (gene <= 0)
            {
                return c.cell;
            }
        }

        return null;
    }

}
