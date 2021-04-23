using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject baseTilePrefab;

    [SerializeField]
    GameObject BlockTilePrefab;

    public AbstractTile[,] tileArray = new AbstractTile[Constants.RowCount, Constants.ColumnCount];
    
    public void CreateLevel()
    {
        GenerateTiles();
    }
    void GenerateTiles()
    {
        GameObject gameObject;
        for (int i = 0; i < Constants.RowCount; i++)
            for (int j = 0; j < Constants.ColumnCount; j++)
            {
                if(i%2!=0 && j%2!=0)
                {
                gameObject = Instantiate(BlockTilePrefab, transform);
                }
                else
                {
                gameObject = Instantiate(baseTilePrefab, transform);
                }
                gameObject.transform.position = new Vector2(j, -i);
                gameObject.GetComponent<AbstractTile>().TilePosition = new Vector2Int(i, j);
                tileArray[i, j] = gameObject.GetComponent<AbstractTile>();
            }

        transform.position = new Vector2(-Constants.ColumnCount / 2 + 0.5f, Constants.RowCount / 2 - 0.5f);
    }
}