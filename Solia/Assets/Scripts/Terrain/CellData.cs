using System;
using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "CellData", menuName = "ScriptableObjects/CellData")]
public class CellData : ScriptableObject
{
    [Tooltip("Liste de cellules utilisables")]
    [SerializeField] public List<Cell> CellList;

    [Tooltip("Taille d'une cellule (suppose cellule carrée)")]
    [SerializeField] public float cellSize;

    public GameObject CellChoice(float dist)
    {
        float summedWeights = 0;
        foreach (Cell c in CellList) //calcul of the sum of all cell's weights taking the difficulty, weight and distance to center into account
        {
            if (dist <= c.optimalDistance)
            {
                summedWeights += (1f + c.weight / 6f) * Mathf.Exp(4f * dist / c.optimalDistance) / 7.36f;
            }
            else
            {
                summedWeights += (1f + c.weight / 6f) * (c.optimalDistance / (dist - 0.865f * c.optimalDistance));
            }
        }
        //seed of the world gen (for now random, can be changed later)
        Random.InitState((int)DateTime.Now.Ticks);
        float gene = Random.Range(0f, 1f) * summedWeights; //generation calcul

        foreach (Cell c in CellList)
        {
            if (dist <= c.optimalDistance)
            {
                gene -= (1f + c.weight / 6f) * Mathf.Exp(4f * dist / c.optimalDistance) / 7.36f;
            }
            else
            {
                gene -= (1f + c.weight / 6f) * (c.optimalDistance / (dist - 0.865f * c.optimalDistance));
            }
            if (gene <= 0)
            {
                return c.cell;
            }
        }

        return null;
    }

    [Serializable]
    public class Cell
    {
        [Tooltip("Objet cellule")]
        public GameObject cell;

        [Tooltip("Distance préférée de la cellule")]
        public int optimalDistance;

        [Tooltip("Poids d'une cellule (pour doubler la chance, il faut un poids 6 fois supérieur)")]
        public int weight;
    }
}