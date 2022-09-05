using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Tooltip("Liste de cellules utilisables")]
    [SerializeField]
    private CellData cellData;
    
    [Tooltip("Distance max de génération du générateur")]
    [SerializeField][Range(1,15)]
    private int distanceMax;

    [Tooltip("Distance à partir de laquelle les cellules se genèrent")] 
    [SerializeField][Range(0,15)]
    private int distanceDeadZone;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position comme centre
        //instancier le parent vide MAP
        GameObject parent = new GameObject("Map");
        //de distDeadzone a distMax
        //executer cellule choice sur l'anneau actuel
        for (int dist = distanceDeadZone; dist < distanceMax; dist++)
        {
            if (dist == 0)
            {
                PlaceCell(0, 0, parent);
                continue;
            }

            for (int y = -dist; y <= dist; y++)
            {
                for (int x = -dist; x <= dist; x++)
                {
                    if ((y != -dist) && (y != dist))
                    {
                        if (x == -dist || x == dist)
                        {
                            PlaceCell(x,y,parent);
                        }
                        continue;
                    }
                    PlaceCell(x,y, parent);
                }
            }
        }
    }


    private void PlaceCell(int x, int y, GameObject center)
    {
        //Chose the cell to spawn (x or y is always equal to dist because we compute on the outside ring)
        GameObject chosenCell = cellData.CellChoice(Mathf.Max(Mathf.Abs(x),Mathf.Abs(y)));
        Instantiate(chosenCell, new Vector3(x * cellData.cellSize, y * cellData.cellSize, 1), Quaternion.identity, center.transform);
    }
}
