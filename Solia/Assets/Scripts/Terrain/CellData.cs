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
        
        [Tooltip("Objet cellule")]
        public GameObject cell;
       
        [Tooltip("Poids d'une cellule (calcul de probabillité)")]
        public int weight;
        
        [Tooltip("Difficulté associée à la cellule")]
        public int difficulty;
        
    }

    [Tooltip("Taille d'une cellule (suppose cellule carrée)")]
    [SerializeField] public float cellSize;
    
    [Tooltip("Liste de cellules utilisables")]
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
        Debug.Log("Gene value: " + gene + ", SumWeight: " + summedWeights);

        foreach (Cell c in CellList)
        {
            if (dist <= c.difficulty)
            {
                gene -= c.weight * (dist / c.difficulty) * 10;
            }
            else
            {
                gene -= c.weight * (c.difficulty / dist) * 10;
            }
            if (gene <= 0)
            {
                return c.cell;
            }
        }

        return null;
    }

}
